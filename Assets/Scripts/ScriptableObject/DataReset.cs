using UnityEngine;

public class DataReset : MonoBehaviour
{
    [SerializeField] WorldState worldState;

    private void OnApplicationQuit()
    {
        ResetWorldState();
    }

    private void ResetWorldState()
    {
        worldState.amountOfWorks = 0;
        worldState.haveClotheOn = false;
        worldState.haveKey = false;
        worldState.getOnCar = false;
        worldState.haveBreakfast = false;
        worldState.haveWallet = false;
        worldState.onTime = false;

        // Reset homeless NPC interaction state
        worldState.foodGivenToHomeless = 0;
    }
}


