using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image _hpBarFilling;

    [SerializeField] HealthController _health;

    private void Awake()
    {
        _health.HealthChanged += OnHealthChanged;
       
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float valuePercent)
    {
        _hpBarFilling.fillAmount = valuePercent;
    }

    
}
