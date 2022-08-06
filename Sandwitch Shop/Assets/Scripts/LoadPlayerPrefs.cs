using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPlayerPrefs : MonoBehaviour
{
    [SerializeField] private bool canUse = false;
    [SerializeField] private MainMenu menuController;
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;



    private void Awake()
    {
        if (canUse)
        {
            if (PlayerPrefs.HasKey("volume"))
            {
                float localVolume = PlayerPrefs.GetFloat("volume");

                AudioListener.volume = localVolume;
                volumeTextValue.text = localVolume.ToString("0.0");
                volumeSlider.value = localVolume;
            }
            else
            {
                menuController.SetVolume(0.5f);
            }
        }
    }
}
