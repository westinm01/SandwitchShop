using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject LoseScreen;
    [SerializeField] GameObject PauseMenu;

    public void WinGame()
    {
        WinScreen.SetActive(true);
    }
    public void LoseGame()
    {
        LoseScreen.SetActive(true);
    }
    public void PauseGame()
    {
        PauseMenu.SetActive(true);
    }
    public void UnpauseGame()
    {
        PauseMenu.SetActive(false);
    }
}
