using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;


public class SitAndWork : MonoBehaviour
{
    [Header("Analytics To Track")]
    [SerializeField] private int getWorkEnding = 0;


    [SerializeField] WorldState checkingState;
    [SerializeField] string levelName;
    [SerializeField] string endingScene;
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

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


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
                    SceneManager.LoadScene(endingScene);
                }
            }

            playerCharacter.transform.position = targetPosition;
            playerMovmementScript.enabled = false;
            checkingPlayerScript.enabled = false;
            playerRb2D.simulated = false;
            StartCoroutine(ChangeSceneAfterWait());

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

    private IEnumerator ChangeSceneAfterWait()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(levelName);
        audioManager.PlaySFX(audioManager.changeScene);
        getWorkEnding++;
        GameAnalytics.NewDesignEvent("WorkEnding", getWorkEnding);
    }

    private IEnumerator ShowImageAndChangeScene()
    {
       

        // Enable the canvas with the image
        canvasWithImage.SetActive(true);

        // Wait for a few seconds (you can adjust this duration)
        yield return new WaitForSeconds(5f);

    }
}