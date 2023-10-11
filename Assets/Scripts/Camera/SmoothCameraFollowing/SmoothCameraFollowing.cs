using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollowing : MonoBehaviour
{
    public Transform target; // The player's transform
    [SerializeField] float smoothSpeed = 0.125f; // Smoothing factor for camera movement
    [SerializeField] float xOffset = 0f; // Offset in X-axis

    public bool isFollowing;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Uh Oh!");
            return;
        }

        if(isFollowing)
        {
            // Calculate the target position for the camera
            // Then Use Mathf.SmoothDamp to smoothly interpolate between current position and target position
            Vector3 targetPosition = new Vector3(target.position.x + xOffset, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
        }
    }
}


