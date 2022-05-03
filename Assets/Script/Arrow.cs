using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speedArrow = 0f;

    [SerializeField] private int _damage = 0;
    
    private Vector2 _enemy;
    private Vector2 _player;

    private void Start()
    {
        _enemy = new Vector2(TargetSystem.target.transform.position.x, TargetSystem.target.transform.position.y);
        _player = new Vector2(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        Shoot();
    }

    private void Shoot()
    {
        var _target = _enemy - _player;
        transform.Translate(_target.normalized * _speedArrow * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HealthController health = other.gameObject.GetComponent<HealthController>();
        if(health != null && other.CompareTag("Enemy"))
        {
            DestroyArrow();
            health.ChangeHealth(-_damage);
        }

        if (other.CompareTag("Wall"))
        {
            DestroyArrow();
        }
    }

    private void DestroyArrow()
    {
        Destroy(gameObject);
    }
}
