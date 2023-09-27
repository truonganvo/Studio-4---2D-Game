using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManTalk : MonoBehaviour
{
    [SerializeField] WorldState checkWorldState;

    //Wear uniform or not
    [SerializeField] GameObject canvas101;
    [SerializeField] GameObject canvas102;

    //Doesn't travel by car
    [SerializeField] GameObject canvas201;

    [SerializeField] GameObject canvas401;

    // Update is called once per frame
    void Update()
    {
        if(checkWorldState.haveClotheOn && checkWorldState.getOnCar)
        {
            canvas101.SetActive(true);
        }
        else if (checkWorldState.haveClotheOn == false && checkWorldState.getOnCar == true)
        {
            canvas102.SetActive(true);
        }
        else if (checkWorldState.getOnCar == false && checkWorldState.haveClotheOn == true)
        {
            canvas201.SetActive(true);
        }
        else if (checkWorldState.haveClotheOn == false && checkWorldState.getOnCar == false)
        {
            canvas401.SetActive(true);
        }
    }
}
