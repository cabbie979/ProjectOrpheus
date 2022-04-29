using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
    private Enemy[] enemy;
    private GameObject _target;

    public static GameObject target;

    


    private void Update()
    {
        enemy = FindObjectsOfType<Enemy>();
        target = EnemyTarget();
    }

    public GameObject EnemyTarget()
    {
        float _distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach(Enemy go in enemy)
        {
            
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < _distance)
                {
                    _target = go.gameObject;
                    _distance = curDistance;
                }
            
        }

        return _target;
    }

    
}
