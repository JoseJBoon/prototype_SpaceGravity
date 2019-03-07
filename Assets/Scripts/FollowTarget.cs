using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;

    Vector3 offset;

    void Awake()
    {
        if(!target)
        {
            Debug.LogWarning($"Warning: FollowTarget at {name} behaviour has no target to follow!");
            Destroy(this);
        }
        
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if(!target)
            return;
        
        transform.position = target.position + offset;
    }
}
