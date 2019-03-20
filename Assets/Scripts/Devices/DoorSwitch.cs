using UnityEngine;
using System.Collections;

public class DoorSwitch : PowerDeviceBehaviour
{
    MovePlatformBehaviour door;
    bool ignoreFirstEnable = true;

    void Awake()
    {
        door = GetComponent<MovePlatformBehaviour>();
    }

    void Start()
    {
        ignoreFirstEnable = false;
    }

    void OnEnable()
    {
        door.SetEndPositionToTarget();
    }

    void OnDisable()
    {
        door.SetEndPositionToStart();
    }
}
