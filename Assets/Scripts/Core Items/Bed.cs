using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour
{
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private int requiredInteractions = 5;
    private int currentInteractions = 0;

    private void Update()
    {
        // Check for player interaction with the bed.
        if (Input.GetKeyDown(KeyCode.E) && playerInteract.IsNearBed())
        {
            currentInteractions++;
            PlayBedAnimation();

            // Check if player has interacted the required number of times.
            if (currentInteractions >= requiredInteractions)
            {
                LoadNextScene();
            }
        }
    }

    private void PlayBedAnimation()
    {
        // Your code for the bed animation goes here.
        Debug.Log("Playing bed animation.");
    }

    private void LoadNextScene()
    {
        // If you are using the built-in Unity Scene Management, you can use the following:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Debug.Log("Loading next scene.");
    }
}

public class PlayerInteract : MonoBehaviour
{
    // Dummy function. This should check if the player is close enough to the bed to interact.
    public bool IsNearBed()
    {
        // Logic for checking if the player is near the bed.
        return true; // Example return.
    }
}
