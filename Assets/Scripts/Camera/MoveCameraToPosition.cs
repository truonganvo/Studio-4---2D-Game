using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraToPosition : MonoBehaviour
{
    public bool isInsideTriggerZone = false;
    [SerializeField] TriggerDifferentArea numbers;

    [SerializeField] float moveNewTargetPositions = 0.0f;
    [SerializeField] float moveBackTargetPositions = 0.0f;

    [SerializeField] Camera cameraSize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInsideTriggerZone && numbers.assignNumber == 2)
        {
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = new Vector3(moveNewTargetPositions, currentPosition.y, currentPosition.z);

            transform.position = targetPosition;
            cameraSize.orthographicSize = 10;
        }
        else if (isInsideTriggerZone && numbers.assignNumber == 1)
        {
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = new Vector3(moveBackTargetPositions, currentPosition.y, currentPosition.z);

            transform.position = targetPosition;
            cameraSize.orthographicSize = 5;
        }
    }
}
