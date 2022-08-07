using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Cached References
    AudioSource myAudioSource;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void RecieveAndPlayMusic(AudioClip music)
    {
        myAudioSource.clip = music;
        myAudioSource.Play();
        myAudioSource.loop = true;
    }
    public void RecieveAndPlaySFX(AudioClip SFX)
    {
        AudioSource.PlayClipAtPoint(SFX, Camera.main.transform.position);
    }

    public void StopMusic()
    {
        myAudioSource.Stop();
    }
}
