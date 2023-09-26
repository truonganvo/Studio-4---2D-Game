using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReset : MonoBehaviour
{
    [SerializeField] WorldState worldState;

    private void OnApplicationQuit()
    {
        worldState.haveClotheOn = false;
        worldState.haveKey = false;
    }
}
