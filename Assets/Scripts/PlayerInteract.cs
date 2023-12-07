using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class PlayerInteract : MonoBehaviour
{
    public bool isInteractable;
    public bool hasPickUp;

    public int itemID = 0;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    private void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Pick UP something");
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

    private void PickUp()
    {
        hasPickUp = true;
        Destroy(gameObject, 0.20f);
        GameAnalytics.NewDesignEvent("Player pick up", itemID);

        switch (itemID)
        {
            case 1:
                audioManager.PlaySFX(audioManager.cloth);
                break;
            case 2:
                audioManager.PlaySFX(audioManager.key);
                break;
            case 3:
                audioManager.PlaySFX(audioManager.food);
                break;
            case 4:
                audioManager.PlaySFX(audioManager.wallet);
                break;
            default:
                break;
        }
    }
}
