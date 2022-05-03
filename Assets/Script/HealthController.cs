using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
  
    [SerializeField] private int _maxHp = 0;
    public int _currentHp = 0;

    public event Action<float> HealthChanged;
    

    private void Start()
    {
        _currentHp = _maxHp;
    }

    public void ChangeHealth(int value)
    {
        _currentHp += value;

        if (_currentHp <= 0)
        {
            Die();
            Coin._coin += 10;
        }
        else
        {
            float currentHPPercent = (float)_currentHp / _maxHp;
            HealthChanged?.Invoke(currentHPPercent);
        }
    }

    private void Die()
    {
        HealthChanged?.Invoke(0);
        Destroy(gameObject);
    }
}
