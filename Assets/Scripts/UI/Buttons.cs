using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private AudioSource buttonAudio;

    public void PlayButtonAudio() => buttonAudio.Play();
}
