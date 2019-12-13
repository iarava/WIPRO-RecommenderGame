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

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.playOnAwake = false;

            s.source.clip = s.audioClip;
            s.source.volume = s.soundData.Volume;
            s.source.loop = s.soundData.Loop;
            s.source.mute = s.soundData.isSoundEnabled();
        }
    }

    public void Play(SoundSetting soundData)
    {
        Sound s = Array.Find(sounds, sound => sound.soundData.SoundName == soundData.SoundName);
        if(s == null)
        {
            Debug.LogWarning("Sound " + soundData.SoundName + " not found");
            return;
        }
        s.source.Play();
    }

    public void Stop(SoundSetting soundData)
    {
        Sound s = Array.Find(sounds, sound => sound.soundData.SoundName == soundData.SoundName);
        if (s == null)
        {
            Debug.LogWarning("Sound " + soundData.SoundName + " not found");
            return;
        }
        s.source.Stop();
    }
}
