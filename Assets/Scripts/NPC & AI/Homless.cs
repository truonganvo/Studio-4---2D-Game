using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;


public class Homeless : MonoBehaviour
{
    [SerializeField] private WorldState worldState; // Assign this in the Inspector
    [SerializeField] private TextMeshProUGUI dialogueText; // Assign this in the Inspector
    [SerializeField] private float moveSpeed = 2f; // Speed at which the homeless character moves
    [SerializeField] private Transform moveTarget; // The target position to move to after being fed twice
    [SerializeField] private string newSceneName; // The name of the new scene to load
    [SerializeField] private GameObject canvasWithImage; // Assign this in the Inspector

    private bool isPlayerInRange = false;
    private bool hasReachedTarget = false;

    [Header("Analytics To Track")]
    [SerializeField] private int getHomelessEnding = 0;
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

        if (worldState.foodGivenToHomeless >= 2 && moveTarget != null && !hasReachedTarget)
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
        switch (worldState.foodGivenToHomeless)
        {
            case 0:
                dialogueText.text = "Do you have any food to spare?";
                break;
            case 1:
                dialogueText.text = "I'm still hungry, could you find more food?";
                break;
            case 2:
                dialogueText.text = "I'm full now, Follow Me";
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
            worldState.GiveFoodToHomeless();
            UpdateDialogue();
        }
        else
        {
            dialogueText.text = "It looks like you don't have any food to give.";
        }
    }

    private void MoveToTarget()
    {
        Vector3 moveDirection = (moveTarget.position - transform.position).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveTarget.position) < 0.1f)
        {
            hasReachedTarget = true;
            StartCoroutine(ShowImageAndChangeScene());
        }
    }

    private IEnumerator ShowImageAndChangeScene()
    {
        yield return new WaitForSeconds(0.1f);

        // Enable the canvas with the image
        canvasWithImage.SetActive(true);

        // Wait for a few seconds (you can adjust this duration)
        yield return new WaitForSeconds(1.5f);

        // Load the new scene
        SceneManager.LoadScene(newSceneName);
        getHomelessEnding++;
        GameAnalytics.NewDesignEvent("ParkEnding", getHomelessEnding);
    }
}
