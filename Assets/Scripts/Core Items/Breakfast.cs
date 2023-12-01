using GameAnalyticsSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakfast : MonoBehaviour
{
    [SerializeField] WorldState checkingState;
    [SerializeField] PlayerInteract playerInteract;

    


    private void Update()
    {
        if (playerInteract.hasPickUp)
        {
            Debug.Log("IT DIES");
            checkingState.haveBreakfast = true;
            
        }
    }
}
