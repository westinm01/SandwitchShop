using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] float time = 180f;

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name != "Tutorial")
        {
            time -= Time.deltaTime;
        }

        if (time <= 0)
        {
            time = 0;
            FindObjectOfType<LevelManager>().LoseGame();
        }
        timerText.text = "Time: " + ((int)time).ToString();
    }
}
