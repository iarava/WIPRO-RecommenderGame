using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound", menuName = "Sound")]
public class Sound : ScriptableObject
{
    [SerializeField]
    private SoundData soundData;

    [SerializeField]
    private AudioClip audioClip;


    private AudioSource audioSource = null;

    public SoundData SoundData
    {
        get
        {
            return soundData;
        }
    }

    public AudioClip AudioClip
    {
        get
        {
            return audioClip;
        }
    }

    public AudioSource AudioSource
    {
        get
        {
            return audioSource;
        }
    }

    public void InitializeSource(AudioSource source)
    {
        audioSource = source;
    }
}
