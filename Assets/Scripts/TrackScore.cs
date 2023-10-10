using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrackScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] WorldState textScore;



    public int numberOfDay = 0;
    public int score = 0;

    private void Update()
    {
        numberOfDay = textScore.amountOfWorks;
        score = numberOfDay;
        scoreText.text = score.ToString();
    }
}
