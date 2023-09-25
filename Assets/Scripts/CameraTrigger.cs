using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private ChangeCameraPosition cameraTrigger;
    [SerializeField] BoxCollider2D boxColliderRight;
    [SerializeField] BoxCollider2D boxColliderLeft;


    public bool triggerMoveRight = false;
    public bool triggerMoveLeft = false;

    public int numbers = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Change "Player" to the tag of the object that triggers the camera movement.
        {
            Debug.Log("Enter!");
            cameraTrigger.isMoving = true;
            if(triggerMoveRight)
            {
                numbers = 1;
                boxColliderRight.enabled= false;
                boxColliderLeft.enabled= true;
                StartCoroutine(TurnBoolFalseAfterDelay());
            }
            else if(triggerMoveLeft)
            {
                numbers = 2;
                boxColliderLeft.enabled= false;
                boxColliderRight.enabled = true;
                StartCoroutine(TurnBoolFalseAfterDelay());
            }
        }
    }
    private IEnumerator TurnBoolFalseAfterDelay()
    {
        yield return new WaitForSeconds(0.25f);

        // After the specified delay, set the boolean to false
        if(triggerMoveRight)
        {
            triggerMoveRight = false;
            triggerMoveLeft = true;
        }
        else if (triggerMoveLeft)
        {
            triggerMoveLeft = false;
            triggerMoveRight = true;
        }
    }
}
