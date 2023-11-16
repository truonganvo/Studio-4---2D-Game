using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SitAndWork : MonoBehaviour
{
    [SerializeField] WorldState checkingState;
    [SerializeField] string levelName;
    [SerializeField] SceneAsset endingScene;
    [SerializeField] bool isInteractable;



    //Player
    [SerializeField] GameObject playerCharacter;
    [SerializeField] PlayerMovement playerMovmementScript;
    [SerializeField] CheckingPlayer checkingPlayerScript;
    [SerializeField] Rigidbody2D playerRb2D;

    //Object to teleport
    [SerializeField] GameObject teleportPoint;

    //Stop working need food
    [SerializeField] GameObject canvasWithImage;
    [SerializeField] float imageDisplayDelay = 0.5f;

    private bool hasInteracted = false;

    private void Update()
    {
        Vector3 targetPosition = teleportPoint.transform.position;

        if (Input.GetKeyDown(KeyCode.E) && isInteractable == true)
        {
            // Check if the player meets the work conditions
            bool canWork = false;

            // Check if the player has the uniform on, has the key, and gets on the car
            if (checkingState.haveClotheOn && checkingState.haveKey && checkingState.getOnCar)
            {
                canWork = true;
            }
            // Check if the player has the uniform on, has the wallet, and is on time
            else if (checkingState.haveClotheOn && checkingState.haveWallet && checkingState.onTime)
            {
                canWork = true;
            }

            // If the player meets the work conditions, increment the number of days worked
            if (canWork)
            {
                checkingState.amountOfWorks++;

                // Check if amountOfWorks is equal to 5 to load the assigned ending scene
                if (checkingState.amountOfWorks == 5)
                {
                    // Load the assigned ending scene
                    SceneManager.LoadScene(endingScene.name);
                }
            }

            hasInteracted = true;
            playerCharacter.transform.position = targetPosition;
            playerMovmementScript.enabled = false;
            checkingPlayerScript.enabled = false;
            playerRb2D.simulated = false;

            StartCoroutine(ShowImageAndChangeScene());
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInteractable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInteractable = false;
        }
    }

    private IEnumerator ShowImageAndChangeScene()
    {
        yield return new WaitForSeconds(imageDisplayDelay);

        // Enable the canvas with the image
        canvasWithImage.SetActive(true);

        // Wait for a few seconds (you can adjust this duration)
        yield return new WaitForSeconds(1.5f);

        // Load the assigned ending scene
        SceneManager.LoadScene(endingScene.name);
    }
}