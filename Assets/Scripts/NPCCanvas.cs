using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCanvas : MonoBehaviour
{
    [SerializeField] Canvas canvy;
    [SerializeField] bool playerInRange;

    private void Start()
    {
        canvy.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canvy.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canvy.enabled = false;
        }
    }
}
