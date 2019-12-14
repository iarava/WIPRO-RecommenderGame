using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SoundData", menuName = "SoundData")]
public class SoundData : ScriptableObject
{
    [SerializeField]
    private string soundName;

    [SerializeField]
    private float volume;
    [SerializeField]
    private bool loop;

    private bool mute = false;

    public string SoundName
    {
        get
        {
            return soundName;
        }
    }

    public float Volume
    {
        get
        {
            return volume;
        }
    }

    public bool Loop
    {
        get
        {
            return loop;
        }
    }

    public bool isSoundEnabled()
    {
        return mute;
    }

    public void enableSound(bool enable) {
        mute = enable;
    }
}
