using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    [SerializeField]
    float smoothStep = 1.0f;

    Vector3 smoothVelocity = Vector3.zero;

    void Awake()
    {
        if(!target)
        {
            Debug.LogWarning($"Warning: FollowTarget at {name} behaviour has no target to follow!");
            Destroy(this);
        }
    }

    void FixedUpdate()
    {
        if (!target)
            return;

        Vector3 targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothStep * Time.deltaTime);
    }

    //void LateUpdate()
    //{
    //    if(!target)
    //        return;
        
    //    // TODO: Add Smoothdamp
    //    transform.position = target.position + offset;
    //}
}
