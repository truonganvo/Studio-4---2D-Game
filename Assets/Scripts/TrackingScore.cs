using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrackingScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] WorldState textScore;

    [SerializeField] GameObject audioManager;

    private int highScore = 0;
    private int score = 0;


    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        highScoreText.text = "HighScores: " + highScore.ToString();
    }
    private void Update()
    {
        scoreText.text = textScore.ToString() + " POINTS";
        score = textScore.amountOfWorks;
        CheckingHighScore();
    }

    public void CheckingHighScore()
    {
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
            Debug.Log("Sound!!!!!!");
            audioManager.SetActive(true);
        }
    }
}
