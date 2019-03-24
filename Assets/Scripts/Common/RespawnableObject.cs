using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class RespawnableObject : MonoBehaviour
{
    [SerializeField]
    float delayRespawn = 1.0f;
    [SerializeField]
    float dragOfRigidbody = 10.0f;

    [SerializeField]
    FadeSprite fadeSprite;
    [SerializeField]
    ParticleSystem particlesSpawn = null;
    [SerializeField]
    ParticleSystem particlesDestroy = null;

    Rigidbody2D rb2d;
    Collider2D collider2d;
    float savedDrag;

    public Vector3 RespawnPosition { get; set; }

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
    }

    void Start()
    {
        RespawnPosition = transform.position;

        if (particlesSpawn)
            particlesSpawn.Play();
    }

    public void StartRespawn()
    {
        // if still running
        if(particlesSpawn)
        {
            particlesSpawn.Clear();
            particlesSpawn.Stop();
        }

        // Disable and remove momentum
        //rb2d.velocity = Vector2.zero;
        //rb2d.angularVelocity = 0;
        //rb2d.MoveRotation(0);
        //rb2d.bodyType = RigidbodyType2D.Kinematic;
        savedDrag = rb2d.drag;
        rb2d.drag = dragOfRigidbody;
        collider2d.enabled = false;
        
        // Fade Out
        if(fadeSprite)
        fadeSprite.StartFade();

        // Particles destroy
        if(particlesDestroy)
            particlesDestroy.Play();

        // Invoke respawn with delay
        Invoke("Respawn", delayRespawn);
    }

    void Respawn()
    {
        // if still running
        if (particlesDestroy)
        {
            Debug.Log("stop particle");
            particlesDestroy.Clear();
            particlesDestroy.Stop();
        }

        // Reposition and re-enable
        transform.position = RespawnPosition;

        rb2d.velocity = Vector2.zero;
        rb2d.angularVelocity = 0;
        rb2d.MoveRotation(0);
        rb2d.drag = savedDrag;

        //rb2d.bodyType = RigidbodyType2D.Dynamic;
        collider2d.enabled = true;

        // Fade in
        if(fadeSprite)
            fadeSprite.ReverseFade();

        // particles
        if(particlesSpawn)
            particlesSpawn.Play();
    }
}
