using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConstantForce2D))]
public class CounterGravityBehaviour : MonoBehaviour
{
    ConstantForce2D constantForce;

    void Awake() 
    {
        constantForce = GetComponent<ConstantForce2D>();
        constantForce.enabled = false;   
    }

    public void EnableConstantForce(Vector2 counterGravity)
    {
        constantForce.enabled = true;
        constantForce.force = counterGravity;
    }

    public void DisableConstantForce(Vector2 counterGravity)
    {
        constantForce.enabled = false;
    }
}
