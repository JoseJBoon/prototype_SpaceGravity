using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlatformBehaviour : MonoBehaviour
{
    Transform onPlatform;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onPlatform = collision.transform;
            onPlatform.parent = transform.parent;
        }
            
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onPlatform.parent = null;
            onPlatform = null;
        }
            
    }
}
