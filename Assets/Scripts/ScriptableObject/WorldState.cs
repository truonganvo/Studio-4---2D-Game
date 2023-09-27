using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WorldState : ScriptableObject
{
    public bool haveClotheOn;

    [Header("Personal Key")]
    //Use personal car
    public bool haveKey;
    public bool getOnCar = false;
}
