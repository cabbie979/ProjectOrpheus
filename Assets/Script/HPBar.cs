using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image _hpBarFilling;

    [SerializeField] HealthController _health;

    private Camera _camera;

    private void Awake()
    {
        _health.HealthChanged += OnHealthChanged;
        _camera = Camera.main;
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float valuePercent)
    {
        _hpBarFilling.fillAmount = valuePercent;
    }

    private void LateUpdate()
    {
        transform.Rotate(0, 180, 0);
    }
}
