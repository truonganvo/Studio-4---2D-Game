using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Homeless : MonoBehaviour
{
    [SerializeField] private WorldState worldState; // Assign this in the Inspector
    [SerializeField] private TextMeshProUGUI dialogueText; // Assign this in the Inspector
    [SerializeField] private float moveSpeed = 2f; // Speed at which the homeless character moves
    [SerializeField] private Transform moveTarget; // The target position to move to after being fed twice
    [SerializeField] private string newSceneName; // The name of the new scene to load

    private bool isPlayerInRange = false;

    private void Start()
    {
        UpdateDialogue();
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ReceiveItem();
        }

        // Check if the homeless character should move
        if (worldState.foodGivenToHomeless >= 2 && moveTarget != null)
        {
            MoveToTarget();
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

    private void MoveToTarget()
    {
        // Calculate the direction to move
        Vector3 moveDirection = (moveTarget.position - transform.position).normalized;

        // Move the character towards the target
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Check if the character has reached the target
        if (Vector3.Distance(transform.position, moveTarget.position) < 0.1f)
        {
            // Load the new scene when the target is reached
            SceneManager.LoadScene(newSceneName);
        }
    }
}
