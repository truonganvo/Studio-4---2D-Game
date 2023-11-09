using UnityEngine;
using TMPro;

public class Homeless : MonoBehaviour
{
    [SerializeField] private WorldState worldState; // Assign this in the Inspector
    [SerializeField] private TextMeshProUGUI dialogueText; // Assign this in the Inspector

    private bool isPlayerInRange = false;

    private void Start()
    {
        // You could initialize dialogueText with an initial value if needed.
        UpdateDialogue();
    }

    private void Update()
    {
        // If the player is in range and presses the 'E' key, give the item.
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ReceiveItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void UpdateDialogue()
    {
        // Check how many times the homeless has been given food
        switch (worldState.foodGivenToHomeless)
        {
            case 0:
                dialogueText.text = "Do you have any food to spare?";
                break;
            case 1:
                dialogueText.text = "I'm still hungry, could you find more food?";
                break;
            case 2:
                dialogueText.text = "I'm full now, thank you! What can I do for you?";
                // Here you can also trigger any actions like moving to a new scene
                break;
            default:
                dialogueText.text = "You've already given me more than enough!";
                break;
        }
    }

    public void ReceiveItem()
    {
        if (worldState.haveBreakfast)
        {
            worldState.GiveFoodToHomeless(); // Handle the logic of giving food
            UpdateDialogue(); // Update the dialogue text
        }
        else
        {
            dialogueText.text = "It looks like you don't have any food to give.";
        }
    }
}
