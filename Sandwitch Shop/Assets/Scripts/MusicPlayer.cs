using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip mainMenuMusic;

    // Cached References
    AudioSource myAudioSource;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {;

        if ((SceneManager.GetActiveScene().name == "MainMenu") && (myAudioSource.isPlaying == false))
        {
            myAudioSource.clip = mainMenuMusic;
            myAudioSource.Play();
            Debug.Log("Play Music!");
        }
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
