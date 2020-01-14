using UnityEngine;

public class PlaySoundDuringLifetime : MonoBehaviour
{
    [SerializeField]
    private AudioManager.SoundType sound;

    private void Start()
    {
        AudioManager.Instance.Play(sound);
    }

    private void OnDestroy()
    {
        AudioManager.Instance.Stop(sound);
    }
}
