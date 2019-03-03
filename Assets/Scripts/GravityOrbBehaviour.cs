using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class GravityOrbBehaviour : MonoBehaviour
{
    public float breakdownTime = 2.0f;

    Collider2D collider;
    Rigidbody2D rigidbody;
    PointEffector2D pointEffector;
    float startForce;
    float endForce;
    float timer;
    bool breakDown;
    
    void Awake()
    {
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        pointEffector = GetComponentInChildren<PointEffector2D>();

        startForce = pointEffector.forceMagnitude;
        endForce = 0.0f;
        breakDown = false;
        timer = 0.0f;
    }

    void Update()
    {
        if(breakDown)
        {
            timer += Time.deltaTime;
            float percentage = timer / breakdownTime;
            pointEffector.forceMagnitude = Mathf.Lerp(startForce, endForce, percentage);

            if(timer > breakdownTime)
                Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        rigidbody.velocity = Vector2.zero;
        collider.enabled = false;
    }
    
    public void LaunchOrb(Vector2 force) => rigidbody.AddForce(force);
    public void ReverseForceMagnitude() => pointEffector.forceMagnitude = -pointEffector.forceMagnitude;
    public void DestroyOrb() => breakDown = true;
}