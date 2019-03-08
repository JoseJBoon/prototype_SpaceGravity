using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AreaEffector2D))]
public class GravityPowerDevice : PowerDeviceBehaviour
{
    AreaEffector2D areaEffector;

    void Awake() 
    {
        areaEffector = GetComponent<AreaEffector2D>();
    }

    void OnEnable() 
    {
        areaEffector.enabled = true;
    }

    void OnDisable()
    {
        areaEffector.enabled = false;
    }
}
