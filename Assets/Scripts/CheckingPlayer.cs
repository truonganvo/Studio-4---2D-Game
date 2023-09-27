using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingPlayer : MonoBehaviour
{
    [SerializeField] private WorldState checkingPlayer;

    //4 main items for the player to pick up
    [SerializeField] private GameObject clothes;

    //4 main things that will trigger based on the items

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checking if one of these four items have been pick up
        if(checkingPlayer.haveClotheOn == true)
        {
            clothes.SetActive(true);
        }
        if(checkingPlayer.haveKey == true)
        {
            
        }
    }
}
