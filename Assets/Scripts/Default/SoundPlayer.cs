using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    AudioSource audioPlayer;

    private void Awake() => audioPlayer = GetComponent<AudioSource>();
    public void PlaySound(AudioClip playSound) => audioPlayer.PlayOneShot(playSound);
    public void ChangeAudioClip(AudioClip newSound) => audioPlayer.clip = newSound;
}