using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BatterySocketBehaviour : MonoBehaviour
{
    [SerializeField]
    PowerDeviceBehaviour powerDevice;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(!other.CompareTag("Battery") || !powerDevice)
            return;

        powerDevice.enabled = true;
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(!other.CompareTag("Battery") || !powerDevice)
            return;

        powerDevice.enabled = false;
    } 

}
