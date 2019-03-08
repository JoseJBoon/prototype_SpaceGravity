using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    Transform lastUnLockedCheckpoint;

    void Awake()
    {
        if (Instance)
            Destroy(gameObject);

        Instance = this;
    }

    public Transform LatestCheckpoint()
    {
        if(lastUnLockedCheckpoint)
            return lastUnLockedCheckpoint;

        return null;
    }

    public void SetCheckPoint(Transform checkpoint)
    {
        if (!checkpoint)
            return;

        lastUnLockedCheckpoint = checkpoint;
    }
}
