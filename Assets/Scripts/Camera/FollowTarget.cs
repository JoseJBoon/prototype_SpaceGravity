using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Awake()
    {
        if(!target)
        {
            Debug.LogWarning($"Warning: FollowTarget at {name} behaviour has no target to follow!");
            Destroy(this);
        }
    }

    void LateUpdate()
    {
        if(!target)
            return;
        
        // TODO: Add Smoothdamp
        transform.position = target.position + offset;
    }
}
