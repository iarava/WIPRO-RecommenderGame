using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundDuringLifetime : MonoBehaviour
{
    [SerializeField]
    private SoundSetting sound;

    private void Start()
    {
        AudioManager.Instance.Play(sound);
    }

    private void OnDestroy()
    {
        AudioManager.Instance.Stop(sound);
    }
}
