using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBehaviour : MonoBehaviour
{
    // TODO: highlight checkpoint
    [SerializeField]
    bool enableOnce = true;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RespawnableObject playerRespawn = collision.GetComponent<RespawnableObject>();

            if(playerRespawn)
                playerRespawn.RespawnPosition = transform.position;

            if (enableOnce)
                GetComponent<Collider2D>().enabled = false;
        }
    }
}
