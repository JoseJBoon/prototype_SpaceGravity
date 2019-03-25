using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// TODO: EventTriggerCaller is probally a better name
public class PowerUnlock : MonoBehaviour
{
    [SerializeField]
    UnityEvent powerToUnlock;
    [SerializeField]
    GameObject spriteOfPower;
    ParticleSystem particle;

    void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            powerToUnlock?.Invoke();
            GetComponent<Collider2D>().enabled = false;
            spriteOfPower?.SetActive(false);

            if (particle)
                particle.Stop();
        }
            
    }
}
