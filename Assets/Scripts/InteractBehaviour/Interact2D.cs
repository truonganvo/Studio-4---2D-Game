
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interact2D : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    public abstract void Interact(); //This interact behaviour allow the player to interact with any item with/depend it own scripts that will call different behaviour e.g: open, pick up, etc...

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("In InteractZone");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Out of InteractZone");
        }
    }
}
