using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SitAndWork : MonoBehaviour
{
    [SerializeField] WorldState checkingState;
    [SerializeField] string levelName;
    [SerializeField] bool isInteractable;

    //Player
    [SerializeField] GameObject playerCharacter;
    [SerializeField] PlayerMovement playerMovmementScript;
    [SerializeField] CheckingPlayer checkingPlayerScript;
    [SerializeField] Rigidbody2D playerRb2D;

    //Object to teleport
    [SerializeField] GameObject teleportPoint;

    //Stop working need food
    [SerializeField] GameObject invisWall;
    [SerializeField] GameObject canvasNeedFood;

    private void Update()
    {
        Vector3 targetPosition = teleportPoint.transform.position;

        if (Input.GetKeyDown(KeyCode.E) && isInteractable == true)
        {
            playerCharacter.transform.position = targetPosition;
            playerMovmementScript.enabled = false;
            checkingPlayerScript.enabled = false;
            playerRb2D.simulated = false;
            StartCoroutine(ChangeSceneAfterWait());
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
    }
}
