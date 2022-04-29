using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private float _speedShot = 0f;
    [SerializeField] private int _damage;

    public Vector2 _player;
    public Vector2 _enemy;

    private void Start()
    {
        _enemy = new Vector2(transform.position.x, transform.position.y);
        _player = FindObjectOfType<Player>().transform.position;
           
    }

    private void Update()
    {
        Gun();
    }

    private void Gun()
    {
        var target = _player - _enemy;
        transform.Translate(target.normalized * _speedShot * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HealthController health = other.gameObject.GetComponent<HealthController>();
        if (other.CompareTag("Player") && health != null)
        {
            Destroy(gameObject);
            health.Decrease(_damage);
        }
            
    }
}
