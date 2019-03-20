using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformBehaviour : PowerDeviceBehaviour
{
    public float speed = 1.0f;
    public float targetTime = 1.0f;
    public bool autoPlatform = false;
    public bool loop = false;

    [SerializeField]
    Transform target;

    [HideInInspector]
    public GravityOrbBehaviour gravityOrb;

    Rigidbody2D rigidbody2D;
    Vector2 startPosition;
    Vector2 endPosition;
    Vector2 smoothVelocity;

    public Vector2 velocity
    {
        get
        {
            return smoothVelocity;
        }
    }

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

        endPosition = startPosition;
    }

    void FixedUpdate()
    {
        if (autoPlatform)
        {
            if(loop)
                ChangeTarget();

            MovePlatform(endPosition);
        }
        else if (gravityOrb)
            PlatformEffector();   
    }

    void MovePlatform(Vector2 targetPosition)
    {
        rigidbody2D.MovePosition(Vector2.SmoothDamp(rigidbody2D.position, targetPosition, ref smoothVelocity, targetTime));
    }

    public void SetEndPositionToStart()
    {
        endPosition = startPosition;
    }

    public void SetEndPositionToTarget()
    {
        endPosition = target.position;
    }

    public void ChangeTarget()
    {
        if (Vector2.Distance(rigidbody2D.position, endPosition) > 0.1f)
            return;

        if (endPosition == startPosition)
            endPosition = target.position;
        else
            endPosition = startPosition;
    }

    void PlatformEffector()
    {
        // TODO: FixedUdate!!!
        //Rigidbody2D rb = collision.attachedRigidbody;

        if (Vector2.Distance(rigidbody2D.position, gravityOrb.transform.position) > .01f)
        {
            Vector2 newPosition = Vector2.MoveTowards(rigidbody2D.position, gravityOrb.transform.position, 2.0f * Time.deltaTime);
            //Vector2 direction = (rb.position - (Vector2)transform.position).normalized * -2.0f * Time.deltaTime;
            MovePlatform(newPosition);
            // Set end position;
            // Can only move along one axis
        }
    }
}
