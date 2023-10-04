using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    public bool isInteractable;
    public bool hasPickUp;

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
    }
}
