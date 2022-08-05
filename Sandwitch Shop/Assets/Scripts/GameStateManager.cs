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
    }
    public void UnpauseGame()
    {
        selectorIcon.SetActive(false);
        PauseMenu.SetActive(false);
    }
}
