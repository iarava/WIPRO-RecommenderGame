﻿using UnityEngine;

[System.Serializable]
public class Sound
{
    public string soundName;

    public AudioManager.SoundType soundType;

    [Range(0f,1f)]
    public float volume;
    public bool loop;
    public bool mute = false;

    public AudioClip audioClip;

    [HideInInspector]
    public AudioSource audioSource;
}
