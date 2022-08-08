using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Music for the Level
    [SerializeField] AudioClip levelMusic;
    [SerializeField] AudioClip bossMusic;

    // Boss Image
    [SerializeField] GameObject bossObject;

    // Win, Pause, and Lose Elements
    [SerializeField] GameObject selectorIcon;
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject LoseScreen;
    [SerializeField] GameObject PauseMenu;

    private void Start()
    {
        FindObjectOfType<MusicPlayer>().RecieveAndPlayMusic(levelMusic);
    }

    public void ActivateBossImage()
    {
        bossObject.SetActive(true);
    }

    public void PlayLevelBossMusic()
    {
        FindObjectOfType<MusicPlayer>().RecieveAndPlayMusic(bossMusic);
    }

    public void WinGame()
    {
        selectorIcon.SetActive(true);
        WinScreen.SetActive(true);
        PauseGameSystems();
    }
    public void LoseGame()
    {
        selectorIcon.SetActive(true);
        LoseScreen.SetActive(true);
        PauseGameSystems();
    }
    public void PauseGame()
    {
        selectorIcon.SetActive(true);
        PauseMenu.SetActive(true);
        PauseGameSystems();
    }
    public void UnpauseGame()
    {
        selectorIcon.SetActive(false);
        PauseMenu.SetActive(false);
        UnpauseGameSystems();
    }

    private void PauseGameSystems()
    {
        Time.timeScale = 0f;
        Destroy(GameObject.FindWithTag("Table").GetComponent<SelectStation>());
        Destroy(GameObject.FindWithTag("Table").GetComponent<RotateStations>());
        // may also need to pause player input here later
    }
    private void UnpauseGameSystems()
    {
        Time.timeScale = 1f;
        GameObject.FindWithTag("Table").AddComponent<RotateStations>();
        // may also need to unpause player input here later
    }
}
