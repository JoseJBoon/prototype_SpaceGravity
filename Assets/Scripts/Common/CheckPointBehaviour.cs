using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBehaviour : MonoBehaviour
{
    static CheckPointBehaviour LastCheckpoint;

    [SerializeField]
    Sprite inactive;
    [SerializeField]
    Sprite active;
    [SerializeField]
    bool enableOnce = true;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RespawnableObject playerRespawn = collision.GetComponent<RespawnableObject>();

            if(playerRespawn)
                playerRespawn.RespawnPosition = transform.position;

            if (enableOnce)
                GetComponent<Collider2D>().enabled = false;

            if(LastCheckpoint)
                LastCheckpoint.Deactivate();

            LastCheckpoint = this;

            Activate();
        }
    }

    public void Activate()
    {
        spriteRenderer.sprite = active;
    }

    public void Deactivate()
    {
        spriteRenderer.sprite = inactive;
    }
}
