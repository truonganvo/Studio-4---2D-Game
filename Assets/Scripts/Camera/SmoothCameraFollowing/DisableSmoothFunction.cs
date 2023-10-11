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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            changeCameraPositionScript.isMoving = true;
        }
    }

    public void DisableOtherCameraScriptFunction()
    {
        changeCameraPositionScript.enabled= false;
        smoothCameraScript.isFollowing = false;
    }
    public void EnableOtherCameraScriptFunction()
    {
        changeCameraPositionScript.enabled= true;
        smoothCameraScript.isFollowing = true;
    }
}
