using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] WorldState checkingState;
    [SerializeField] PlayerInteract playerInteract;


    private void Update()
    {
        if (playerInteract.hasPickUp)
        {
            Debug.Log("IT DIES");
            checkingState.haveWallet = true;
        }
    }
}
