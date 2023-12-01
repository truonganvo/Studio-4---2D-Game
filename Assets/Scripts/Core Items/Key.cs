using GameAnalyticsSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] WorldState checkingState;
    [SerializeField] PlayerInteract playerInteract;

    

    private void Update()
    {
        if (playerInteract.hasPickUp)
        {
            Debug.Log("IT DIES");
            checkingState.haveKey = true;
        }
            
    }
}
