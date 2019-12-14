using UnityEngine;
using System;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField]
    private Sound[] sounds;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        
    }

    private void Start()
    {
        foreach (Sound s in sounds)
        {
            s.InitializeSource(gameObject.AddComponent<AudioSource>());

            s.AudioSource.playOnAwake = false;

            s.AudioSource.clip = s.AudioClip;
            s.AudioSource.volume = s.SoundData.Volume;
            s.AudioSource.loop = s.SoundData.Loop;
            s.AudioSource.mute = s.SoundData.isSoundEnabled();
        }
    }

    public void Play(SoundData soundData)
    {
        Sound s = Array.Find(sounds, sound => sound.SoundData.SoundName == soundData.SoundName);
        if(s == null)
        {
            Debug.LogWarning("Sound " + soundData.SoundName + " not found");
            return;
        }
        s.AudioSource.volume = s.SoundData.Volume;
        s.AudioSource.Play();
    }

    public void Stop(SoundData soundData)
    {
        Sound s = Array.Find(sounds, sound => sound.SoundData.SoundName == soundData.SoundName);
        if (s == null)
        {
            Debug.LogWarning("Sound " + soundData.SoundName + " not found");
            return;
        }
        s.AudioSource.Stop();
    }
}
