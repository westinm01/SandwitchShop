using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] float time = 180f;

    private void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            time = 0;
            FindObjectOfType<GameStateManager>().LoseGame();
        }
        timerText.text = "Time: " + ((int)time).ToString();
    }
}
