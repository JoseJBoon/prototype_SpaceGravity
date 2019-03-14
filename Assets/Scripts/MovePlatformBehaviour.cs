using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformBehaviour : MonoBehaviour
{
    public float speed = 1.0f;
    public float distance = 2.0f;
    public bool freezePlatform = false;

    [HideInInspector]
    public GravityOrbBehaviour gravityOrb;

    Rigidbody2D rigidbody2D;
    Vector2 startPosition;
    Vector2 previousPosition;

    Vector2 platformVelocity;

    public Vector2 velocity
    {
        get
        {
            return platformVelocity;
        }
    }

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        platformVelocity = Vector2.zero;
    }

    void FixedUpdate()
    {
        platformVelocity = PlatformVelocity();

        if (!freezePlatform)
            MovePlatform();
        else if (gravityOrb)
            PlatformEffector();

        previousPosition = rigidbody2D.position;
    }

    void MovePlatform()
    {
        float x = Mathf.Sin(Time.time * speed) * distance;
        rigidbody2D.MovePosition(startPosition + new Vector2(x, 0));
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

    Vector2 PlatformVelocity()
    {
        return (rigidbody2D.position - previousPosition) / Time.fixedDeltaTime;
    }
}
