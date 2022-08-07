using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    int score = 0;

    // Getter Method
    public int GetScore()
    {
        return score;
    }

    // Setter Methods
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }
    public void SubtractScore(int amount)
    {
        score -= amount;
        UpdateScoreText();
    }
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
