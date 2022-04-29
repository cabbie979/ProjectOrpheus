using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int _maxHp = 0;
    private int _currentHp = 0;

    public event Action<float> HealthChanged;

    private void ChangeHealth(int value)
    {
        _currentHp += value;

        if (_currentHp <= 0)
        {
            Die();
        }
        else
        {
            float currentHPPercent = (float)_currentHp / _maxHp;
            HealthChanged?.Invoke(currentHPPercent);
        }
    }

    public void Decrease(int value)
    {
        _currentHp = (int)Mathf.Clamp(_currentHp - value, 0f, _maxHp);
    }

    private void Die()
    {
        HealthChanged?.Invoke(0);
        Destroy(gameObject);
    }
}
