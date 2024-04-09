using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private protected AudioClip[] sounds;

    private AudioSource audioScr => GetComponent<AudioSource>();

    public void PlaySound(AudioClip sound, float volume = 1f, bool destroyed = false)
    {
        audioScr.pitch = 1;
        audioScr.PlayOneShot(sound, volume);
    }
}
