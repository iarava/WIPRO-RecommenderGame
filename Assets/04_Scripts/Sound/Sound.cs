using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public SoundSetting soundData;

    public AudioClip audioClip;

    [HideInInspector]
    public AudioSource source;
}
