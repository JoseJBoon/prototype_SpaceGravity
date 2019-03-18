using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField]
        bool startOnLoad = false;
        [SerializeField]
        bool enableAllPlatforms = false;
        [SerializeField]
        SidewaysPlatformMover[] platforms;


        void Start()
        {
            SetAllPlatformState(startOnLoad);
            enableAllPlatforms = startOnLoad;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
                SetAllPlatformState(!enableAllPlatforms);

            for (int i = 0; i < platforms.Length; i++)
            {
                string sKeyInput = $"{i}";
                if (Input.GetKeyDown(sKeyInput))
                    TogglePlatformState(i);
            }
        }

        void SetAllPlatformState(bool state)
        {
            foreach (SidewaysPlatformMover platform in platforms)
                platform.enabled = state;
        }

        void TogglePlatformState(int index)
        {
            platforms[index].enabled = !platforms[index].enabled;
        }
    }

}

