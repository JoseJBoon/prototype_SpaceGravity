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

            Debug.DrawRay(transform.position, projection, Color.blue);

            endPosition = transform.position + projection;

            // TODO: Restrict movement within boundries
            //if (Vector2.Distance(endPosition, startPosition) < 0.01f)
            //    endPosition = startPosition;
            //else if (endPosition.magnitude > target.position.magnitude)
            //    endPosition = target.position;

            MovePlatform(endPosition);
        }
    }
}
