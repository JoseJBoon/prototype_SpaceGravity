using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    // if left empty it will disable all objects that come within the trigger zone
    [SerializeField]
    string[] killTags; 

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Exception to prevent overlaping killzones to kill each other.
        if (collision.CompareTag("Killer"))
            return;

        if (killTags.Length == 0)
        {
            KillObject(collision);
            return;
        }
            

        foreach(string killTag in killTags)
        {
            if (collision.CompareTag(killTag))
            {
                KillObject(collision);
                break;
            }
        }
        
    }

    void KillObject(Collider2D objectToKill)
    {
        RespawnableObject resObject = objectToKill.GetComponent<RespawnableObject>();

        if(!resObject)
        {
            // TODO: Consider destroying these objects?
            objectToKill.gameObject.SetActive(false);
            return;
        }

        resObject.StartRespawn();
    }
}
