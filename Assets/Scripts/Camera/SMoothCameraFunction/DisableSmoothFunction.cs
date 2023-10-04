using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSmoothFunction : MonoBehaviour
{
    [SerializeField] ChangeCameraPosition changeCameraPositionScript;
    [SerializeField] SmoothCameraFollowing smoothCameraScript;

    [SerializeField] bool enterNextRoom;
    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            changeCameraPositionScript.isMoving = false;
            smoothCameraScript.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            smoothCameraScript.enabled = true;
            changeCameraPositionScript.isMoving = true;
        }
    }
}
