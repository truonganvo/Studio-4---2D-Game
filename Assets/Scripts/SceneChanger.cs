using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger: MonoBehaviour
{
    public float delayInSeconds = 5f; // Change this to the desired delay

    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delayInSeconds)
        {
            // Change "YourSceneName" to the actual name of the scene you want to load
            SceneManager.LoadScene("HomeLevel");
        }
    }
}

