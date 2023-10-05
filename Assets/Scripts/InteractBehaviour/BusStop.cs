using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BusStop : MonoBehaviour
{
    [SerializeField] WorldState checkingState;
    [SerializeField] string levelName;
    [SerializeField] bool isInteractable;

    private void Update()
    {
        if (checkingState.haveWallet && Input.GetKeyDown(KeyCode.E) && isInteractable == true)
        {
            checkingState.onTime = true;
            SceneManager.LoadScene(levelName);
            Debug.Log("Get On");
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
}
