using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTheSmooth : MonoBehaviour
{
    [SerializeField] SmoothCameraFollowing smoothCameraFollow;
    [SerializeField] CameraTrigger cameraTriggerScript;
    [SerializeField] PlayerInteract playerInteractScript;

    // Update is called once per frame
    void Update()
    {
        if(cameraTriggerScript.triggerMoveRight == false && playerInteractScript.isInteractable == false)
        {
            StartCoroutine(TriggerTheScriptOrNot());
        }
        if (cameraTriggerScript.triggerMoveLeft == false)
        {
            smoothCameraFollow.enabled = false;
        }
    }

    private IEnumerator TriggerTheScriptOrNot()
    {
        yield return new WaitForSeconds(0.5f);
        smoothCameraFollow.enabled = true;
    }
}
