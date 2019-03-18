using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Serializable]
    public class SoundEffect
    {
        public string AudioName;
        public AudioClip Soundfx;
    }

    public static AudioManager Instance = null;
    [SerializeField]
    List<SoundEffect> SoundEffects = new List<SoundEffect>();
    AudioSource audioSource;

    void Awake()
    {
        if(Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string soundName, Vector3 point)
    {
        SoundEffect soundeffect = SoundEffects.Find(x => x.AudioName == name);
        if(soundeffect == null)
        {
            Debug.LogWarning($"AudioManager: Sound {soundName} not found!");
            return;
        }        

        AudioSource.PlayClipAtPoint(soundeffect.Soundfx, point);
    }
}
