using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using GameAnalyticsSDK;
using UnityEngine;

public class Clothes : MonoBehaviour 
{
    [SerializeField] WorldState checkingState;
    [SerializeField] PlayerInteract playerInteract;

  

    private void Update()
    {
        if(playerInteract.hasPickUp)
        {
            Debug.Log("IT DIES");
            checkingState.haveClotheOn = true;
           

        }
    }
}
