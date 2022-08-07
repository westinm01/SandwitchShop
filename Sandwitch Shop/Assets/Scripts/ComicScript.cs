using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicScript : MonoBehaviour
{
    [SerializeField] GameObject instructionText;
    [SerializeField] Sprite[] comicPics;
    [SerializeField] GameObject[] comicText;
    [SerializeField] AudioClip[] playAudioOnPics;
    //[Header("Shake Screen On Pic")]
    [SerializeField] bool[] shakeScreenOnPics;
    [SerializeField] float shakeIntensity = 10f;
    [SerializeField] float shakeFrequency = 0.5f;
    [SerializeField] float shakeDuration = 0.5f;
    int currentPic = 0;


    // Update is called once per frame

    private void Start()
    {
        if(playAudioOnPics[currentPic] != null)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(playAudioOnPics[currentPic]);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && (currentPic + 1 < comicPics.Length))
        {
            if(currentPic == 0)
            {
                instructionText.SetActive(false);
            }
            currentPic++;
            foreach (GameObject text in comicText)
            {
                if(text != null)
                {
                    text.SetActive(false);
                }
            }
            if (comicText[currentPic] != null)
            {
                comicText[currentPic].SetActive(true);
            }
            if(shakeScreenOnPics[currentPic]) {
                FindObjectOfType<CinemachineShake>().ShakeCamera(shakeIntensity, shakeFrequency, shakeDuration);
            }
            if(playAudioOnPics[currentPic] != null)
            {
                Camera.main.GetComponent<AudioSource>().PlayOneShot(playAudioOnPics[currentPic]);
            }
            if((currentPic + 1 == comicPics.Length) && Input.GetKeyDown(KeyCode.DownArrow))
            {
                FindObjectOfType<SceneLoader>().LoadNextScene();
            }
        }
        GetComponent<SpriteRenderer>().sprite = comicPics[currentPic];

    }
}
