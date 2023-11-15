using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrackScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] WorldState textScore;

    public int score = 0;

    private void Update()
    {
        // Get the number of days worked from the WorldState script
        score = textScore.amountOfWorks;
        scoreText.text = score.ToString();
    }
}
