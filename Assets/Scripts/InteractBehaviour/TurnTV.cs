using UnityEngine;
public class TurnTV : Interact2D
{
    [SerializeField] GameObject tvOff;
    [SerializeField] bool isInteract;
    public override void Interact()
    {
        if (isInteract)
        {
            tvOff.SetActive(false);
            Debug.Log("INTERACT AGAIN!");
            isInteract = false;
        }
        else
        {
            tvOff.SetActive(true);
            Debug.Log("INTERACT!");
            isInteract= true;
        }
    }
}
