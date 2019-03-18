using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlatformBehaviour : MonoBehaviour
{
    MovePlatformBehaviour platform;
    CharacterController2D character;

    void Awake()
    {
        platform = GetComponentInParent<MovePlatformBehaviour>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            character = collision.GetComponent<CharacterController2D>();
            character.externalMomentum = platform;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            character.externalMomentum = null;
            character = null;
        }
    }
}
