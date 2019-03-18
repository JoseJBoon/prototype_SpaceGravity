using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public struct PlayerUnlocks
    {
        public bool PrimaryFire;
        public bool SecondaryFire;
        public bool WeaponSwappingUnlocked;
    }

    public static GameManager Instance;

    Transform lastUnLockedCheckpoint;
    PlayerUnlocks playerUnlocks;

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
            
        Instance = this;
        playerUnlocks = new PlayerUnlocks() { PrimaryFire = true, WeaponSwappingUnlocked = false };
        DontDestroyOnLoad(gameObject);
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

    public PlayerUnlocks GetPlayerUnlocks()
    {
        return playerUnlocks;
    }

    public void TogglePrimaryFirePower()
    {
        playerUnlocks.PrimaryFire = !playerUnlocks.PrimaryFire;
    }

    public void ToggleSecondaryFire()
    {
        playerUnlocks.SecondaryFire = !playerUnlocks.SecondaryFire;
    }
}
