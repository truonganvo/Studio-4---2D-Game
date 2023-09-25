using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraPosition : MonoBehaviour
{
    [SerializeField] float smoothSpeed = 5.0f; // Adjust this value to control the smoothness of camera movement.
    [SerializeField] float rightBoxTriggerX = 10.0f; // The target X position where you want to move the camera.
    [SerializeField] float leftBoxTriggerX = 10.0f; // The target X position where you want to move the camera.

    [SerializeField] CameraTrigger cameraTrigger;

    public bool isMoving = false;

    private void Update()
    {
        if(isMoving)
        {
            MoveCameraSmoothly();
        }
    }

    private void MoveCameraSmoothly()
    {
        if (cameraTrigger.numbers == 1)
        {
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = new Vector3(rightBoxTriggerX, currentPosition.y, currentPosition.z);

            // Interpolate between the current position and the target position smoothly.
            Vector3 smoothedPosition = Vector3.Lerp(currentPosition, targetPosition, smoothSpeed * Time.deltaTime);

            transform.position = smoothedPosition;
            Debug.Log("MOVE RIGHT");
        }
        else if (cameraTrigger.numbers == 2)
        {
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = new Vector3(leftBoxTriggerX, currentPosition.y, currentPosition.z);

            Vector3 smoothedPosition = Vector3.Lerp(currentPosition, targetPosition, smoothSpeed * Time.deltaTime);

            transform.position = smoothedPosition;
            Debug.Log("MOVE LEFT");
        }
    }
}
