using UnityEngine;

public class PlayerStateReset : MonoBehaviour
{
    [SerializeField] WorldState worldState;

    // Start is called before the first frame update
    void Start()
    {
        ResetPlayerState();
    }

    private void ResetPlayerState()
    {
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
