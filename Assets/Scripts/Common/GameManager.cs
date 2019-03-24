using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public struct PlayerUnlocks
    {
        public bool PrimaryFire;
        public bool SecondaryFire;
        public bool GraveOTool;
        public bool GraveETool;
        public bool WeaponSwappingUnlocked;
    }

    public static GameManager Instance;

    PlayerUnlocks playerUnlocks;

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
            
        Instance = this;
        playerUnlocks = new PlayerUnlocks();
        DontDestroyOnLoad(gameObject);
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
