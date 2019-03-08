using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAtCheckpointBehaviour : MonoBehaviour
{
    public void SpawnAtCheckpoint()
    {
        if (GameManager.Instance?.LatestCheckpoint())
            transform.position = GameManager.Instance.LatestCheckpoint().position;
    }
}
