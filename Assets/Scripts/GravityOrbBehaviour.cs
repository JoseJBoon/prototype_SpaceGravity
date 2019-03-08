using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class GravityOrbBehaviour : MonoBehaviour
{
    public float breakdownTime = 2.0f;
    public Color attractColor = new Color(0, 0.695f, 0.99f, 0.256f);
    public Color repelColor = new Color(0.604f, 0.082f, 0.0432f, 0.256f);

    Collider2D collider;
    Rigidbody2D rigidbody;
    PointEffector2D pointEffector;
    SpriteRenderer spriteRendererEffector;
    float startForce;
    float endForce;
    float timer;
    bool breakDown;

    public bool IsFrozen
    {
        get
        {
            return rigidbody.bodyType == RigidbodyType2D.Kinematic;
        }
    }
    
    void Awake()
    {
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        pointEffector = GetComponentInChildren<PointEffector2D>();
        spriteRendererEffector = GetComponentsInChildren<SpriteRenderer>()[1]; // :(

        startForce = pointEffector.forceMagnitude;
        endForce = 0.0f;
        breakDown = false;
        timer = 0.0f;
        spriteRendererEffector.color = attractColor;
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
        FreezeOrb();
    }

    public void FreezeOrb()
    {
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        rigidbody.velocity = Vector2.zero;
        collider.enabled = false;
    }

    public void ReverseForceMagnitude()
    {
        pointEffector.forceMagnitude = -pointEffector.forceMagnitude;
        spriteRendererEffector.color = repelColor;
        startForce = pointEffector.forceMagnitude;
    }
    
    public void LaunchOrb(Vector2 force) => rigidbody.AddForce(force);
    public void DestroyOrb() => breakDown = true;
}