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
        Debug.DrawLine(startPosition, target.position, Color.green);
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
        if (Vector2.Distance(rigidbody2D.position, gravityOrb.transform.position) > .01f)
        {
            Vector3 headTo = gravityOrb.transform.position - transform.position;
            Vector3 direction = target.position - (Vector3)startPosition;
            Vector3 projection = Vector3.Project(headTo, direction);

            endPosition = transform.position + projection;

            Vector3 unitDirection = direction.normalized;
            Vector2 fromStart = startPosition + (Vector2)(projection.magnitude * unitDirection);

            // Restrict movement within boundries
            if (!IsCBetweenAB(startPosition, target.position, endPosition))
            {
                // TODO: Do more research :)
                Vector3 deltaFromStart = endPosition - startPosition;
                Vector3 deltaFromTarget = (Vector3)endPosition - target.position;

                if (!IsCBetweenAB(transform.position, startPosition, endPosition) && deltaFromStart.magnitude < deltaFromTarget.magnitude)
                    endPosition = startPosition;
                else if(!IsCBetweenAB(transform.position, target.position, endPosition))
                    endPosition = target.position;
            }

            MovePlatform(endPosition);
        }
    }

    // https://forum.unity.com/threads/how-to-check-a-vector3-position-is-between-two-other-vector3-along-a-line.461474/
    bool IsCBetweenAB(Vector3 A, Vector3 B, Vector3 C)
    {
        return Vector3.Dot((B - A).normalized, (C - B).normalized) < 0f && Vector3.Dot((A - B).normalized, (C - A).normalized) < 0f;
    }
}
