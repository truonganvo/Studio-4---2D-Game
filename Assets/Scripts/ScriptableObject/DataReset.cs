using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReset : MonoBehaviour
{
    [SerializeField] WorldState worldState;

    private void OnApplicationQuit()
    {
        worldState.amountOfWorks= 0;
        worldState.haveClotheOn = false;
        worldState.haveKey = false;
        worldState.getOnCar = false;
        worldState.haveBreakfast= false;
        worldState.haveWallet = false;
        worldState.onTime = false;
    }
}
