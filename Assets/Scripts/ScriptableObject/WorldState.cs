using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WorldState : ScriptableObject
{
    [Header("Work")]
    public int amountOfWorks = 0;

    [Header("Uniform")]
    public bool haveClotheOn;

    [Header("Car")]
    public bool haveKey;
    public bool getOnCar = false;

    [Header("Food")]
    public bool haveBreakfast;
    public int foodGivenToHomeless;

    [Header("Wallet")]
    public bool haveWallet;
    public bool onTime;

    // Method to give food to the homeless. This will be called from the Homeless script.
    public void GiveFoodToHomeless()
    {
        if (haveBreakfast)
        {
            haveBreakfast = false; // The player has given the breakfast away
            foodGivenToHomeless++; // Increment the food given counter
        }
    }
}
