using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour
{
    [SerializeField] string levelName;
    private bool isPlayerNear = false;
    private int interactionCount = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNear)
        {
            interactionCount++;
            Debug.Log($"Interacted with bed {interactionCount} times.");

            if (interactionCount == 5)
            {
                Debug.Log("Loading the next scene after 5 interactions with the bed.");
                SceneManager.LoadScene(levelName);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Player is near the bed.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Player has left the bed.");
        }
    }
}
