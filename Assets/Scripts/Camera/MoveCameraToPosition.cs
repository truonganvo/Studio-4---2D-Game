using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraToPosition : MonoBehaviour
{
    //This script use have similar function as Change Camera Position Scripts but serve as second transition to a third level.
    public Transform targetPosition; // The position the camera should move towards
    public float moveSpeed = 5.0f;   // The speed at which the camera moves

    public bool isInsideTriggerZone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInsideTriggerZone)
        {
            // Calculate the direction from the camera to the target position
            Vector3 direction = targetPosition.position - transform.position;

            // Normalize the direction to get a unit vector
            direction.Normalize();

            // Move the camera towards the target position
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}
