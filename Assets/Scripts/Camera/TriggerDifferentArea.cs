using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDifferentArea : MonoBehaviour
{
    [SerializeField] MoveCameraToPosition moveCameraPositionScript;
    public int assignNumber;

    [SerializeField] Transform newPosition;
    [SerializeField] Transform oldPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            moveCameraPositionScript.isInsideTriggerZone= true;
            if(moveCameraPositionScript.isInsideTriggerZone && assignNumber == 1)
            {
                assignNumber = 2;
                collision.transform.position = newPosition.position;
            }
            else if ((moveCameraPositionScript.isInsideTriggerZone && assignNumber == 2))
            {
                assignNumber = 1;
                collision.transform.position = oldPosition.position;
            }
        }
    }
}
