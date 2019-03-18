using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformBehaviour : MonoBehaviour
{
    public float speed = 1.0f;
    public float targetTime = 1.0f;
    public bool freezePlatform = false;

    [SerializeField]
    Transform target;

    [HideInInspector]
    public GravityOrbBehaviour gravityOrb;

    Rigidbody2D rigidbody2D;
    Vector2 startPosition;
    Vector2 targetPosition;
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

        if (target)
            targetPosition = target.position;
        else
            freezePlatform = true;
    }

    void FixedUpdate()
    {
        if (!freezePlatform)
            MovePlatform();
        else if (gravityOrb)
            PlatformEffector();   
    }

    void MovePlatform()
    {
        if (Vector2.Distance(rigidbody2D.position, target.position) < 0.1f)
            targetPosition = startPosition;  
        else if (Vector2.Distance(rigidbody2D.position, startPosition) < 0.1f)
            targetPosition = target.position;
         
        rigidbody2D.MovePosition(Vector2.SmoothDamp(rigidbody2D.position, targetPosition, ref smoothVelocity, targetTime));
    }

    void PlatformEffector()
    {
        // TODO: FixedUdate!!!
        //Rigidbody2D rb = collision.attachedRigidbody;

        if (Vector2.Distance(rigidbody2D.position, gravityOrb.transform.position) > .01f)
        {
            Vector2 newPosition = Vector2.MoveTowards(rigidbody2D.position, gravityOrb.transform.position, 2.0f * Time.deltaTime);
            //Vector2 direction = (rb.position - (Vector2)transform.position).normalized * -2.0f * Time.deltaTime;
            rigidbody2D.MovePosition(newPosition);
        }
    }
}
