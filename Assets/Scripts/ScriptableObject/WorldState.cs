using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WorldState : ScriptableObject
{
    [Header("Personal Key")]
    public int amountOfWorks = 0;

    [Header("Uniform")]
    public bool haveClotheOn;

    [Header("Personal Key")]
    //Use personal car
    public bool haveKey;
    public bool getOnCar = false;

    [Header("Food")]
    public bool haveBreakfast;

    [Header("Wallet")]
    public bool haveWallet;
    public bool onTime;
}
