using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [Header("Distance")]
    [SerializeField] private float _stopDistance = 0f;
    [SerializeField] private float _retreatDistance = 0f;
    [SerializeField] private float _agrDistance = 0f;
    [Header("EnemyShoot")]
    [SerializeField] private float _startTimeBtwShots = 0;
    [SerializeField] private float _gunDistace = 0f;
    [SerializeField] private GameObject _shotPrefab;

    private float _timeBtwShots;

    public Transform _player;
    
    
    private void Start()
    {
        _player = FindObjectOfType<Player>().transform;

        _timeBtwShots = _startTimeBtwShots;
    }

    private void Update()
    {
        
        if (_player != null)
        {
            EnemyDistance();
            EnemyShoot();
        }
        
    }

    private void EnemyDistance()
    {
        if (Vector2.Distance(transform.position, _player.position) > _stopDistance && (Vector2.Distance(transform.position, _player.position) < _agrDistance))
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
        }

        else if (Vector2.Distance(transform.position, _player.position) < _stopDistance && (Vector2.Distance(transform.position, _player.position) > _retreatDistance))
        {
            transform.position = this.transform.position;
        }

        else if (Vector2.Distance(transform.position, _player.position) < _retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, -_speed * Time.deltaTime);
        }
    }

    private void EnemyShoot()
    {
        if (_timeBtwShots <= 0)
        {
            if (Vector2.Distance(transform.position, _player.transform.position) < _gunDistace)
            {
                Instantiate(_shotPrefab, transform.position, Quaternion.identity);
                _timeBtwShots = _startTimeBtwShots;
            }
        }
        else
        {
            _timeBtwShots -= Time.deltaTime;
        }

        
        
    }
}
