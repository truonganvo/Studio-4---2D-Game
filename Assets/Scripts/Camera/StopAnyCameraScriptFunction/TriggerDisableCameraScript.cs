using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDisableCameraScript : MonoBehaviour
{
    [SerializeField] DisableCameraScript disableCameraScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            disableCameraScript.isStop = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            disableCameraScript.isStop = false;
        }
    }
}
