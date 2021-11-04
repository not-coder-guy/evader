using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;

    // Set the score to 0
    public void Start()
    {
        PrintScore(0);
    }

    // Update the score
    public void AddScore(int amount)
    {
        if (Health.instance.health > 0)
        {
            score += amount;
        }
    }

    // Print the score
    public void PrintScore(int score)
    {
        scoreText.text = score.ToString();
        finalScoreText.text = "Your Score: " + score;
        // Debug.Log("Score: " + score);
    }

    // Update Score when the bomb explodes
    public void OnTriggerEnter2D(Collider2D bomb)
    {
        if (bomb.gameObject.tag == "Bomb")
        {
            AddScore(1);
            PrintScore(score);
        }
    }
}
