using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderTimer : MonoBehaviour
{
    float timeLeft = 20f;
    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0f)
        {
            // Lose game if timer runs out of time
            timeLeft = 0f;
            FindObjectOfType<GameStateManager>().LoseGame();
        }
        slider.value = timeLeft;
    }

    public void UpdateMaxTime(float newMax)
    {
        slider.maxValue = newMax;
        timeLeft = newMax;
    }
}
