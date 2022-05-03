using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BowShoot : MonoBehaviour
{
    [SerializeField] private Transform _bow;
    [SerializeField] private GameObject _arrowPrefab;
    [SerializeField] private float _startTimeBtwShots = 0;
    [SerializeField] private float _gunDistace = 0f;

    public static Action onWin;

    private float _timeBtwShots;

    private void Start()
    {
       
        _timeBtwShots = _startTimeBtwShots;
    }

    private void Update()
    {
        if (TargetSystem.target != null)
        {
            Gun(); 
        }
        else
        {
            onWin?.Invoke();
        }
    }

    private void Gun()
    {
        if (_timeBtwShots <= 0)
        {
            if (Vector2.Distance(transform.position, TargetSystem.target.transform.position) < _gunDistace )
            {
                Instantiate(_arrowPrefab, _bow.position, Quaternion.identity);
                _timeBtwShots = _startTimeBtwShots;
            }
        }
        else
        {
            _timeBtwShots -= Time.deltaTime;
        }
    }
}
