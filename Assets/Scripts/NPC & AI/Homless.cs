using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Homeless : MonoBehaviour
{
    [SerializeField] WorldState checkingState;
    [SerializeField] bool isInteractable;

    // Reference to your TextMeshProUGUI component
    [SerializeField] TextMeshProUGUI canvasText;

    // Text messages
    [SerializeField] string firstText = "Thank you";
    [SerializeField] string secondText = "Sorry for disturb";

    // Player interaction range
    [SerializeField] Collider2D interactionRange; // changed to Collider2D

    private bool playerInRange = false;
    private bool hasInteracted = false;

    private void OnTriggerEnter2D(Collider2D other) // changed to 2D
    {
        // Check if it's the player entering the interaction range
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            isInteractable = true; // The player can now interact
        }
    }

    private void OnTriggerExit2D(Collider2D other) // changed to 2D
    {
        // Check if it's the player exiting the interaction range
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            isInteractable = false; // The player can no longer interact

            // If the player hasn't interacted, display the second message
            if (!hasInteracted)
            {
                canvasText.text = secondText;
            }
        }
    }

    private void Update()
    {
        if (isInteractable && checkingState.haveWallet && Input.GetKeyDown(KeyCode.E))
        {
            hasInteracted = true;
            canvasText.text = firstText;
        }
    }
}
