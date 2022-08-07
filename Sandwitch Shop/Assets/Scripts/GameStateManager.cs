using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] GameObject selectorIcon;
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject LoseScreen;
    [SerializeField] GameObject PauseMenu;

    public void WinGame()
    {
        selectorIcon.SetActive(true);
        WinScreen.SetActive(true);
    }
    public void LoseGame()
    {
        selectorIcon.SetActive(true);
        LoseScreen.SetActive(true);
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
        // may also need to pause player input here later
    }
    private void UnpauseGameSystems()
    {
        Time.timeScale = 1f;
        // may also need to unpause player input here later
    }
}
