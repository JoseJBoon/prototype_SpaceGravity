using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPlatformBehaviour : MonoBehaviour
{
    GravityOrbBehaviour orbBehaviour;
    PointEffector2D pointEffector;

    void Awake()
    {
        orbBehaviour = GetComponentInParent<GravityOrbBehaviour>();
        pointEffector = GetComponent<PointEffector2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            collision.GetComponent<MovePlatformBehaviour>().gravityOrb = orbBehaviour;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            Debug.Log("Poof");
            collision.GetComponent<MovePlatformBehaviour>().gravityOrb = null;
        }
    }
}
