using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManTalk : MonoBehaviour
{
    [SerializeField] WorldState checkWorldState;

    //Car
    [SerializeField] GameObject canvas101;
    [SerializeField] GameObject canvas102;

    //Walk
    [SerializeField] GameObject canvas201;

    //Transport
    [SerializeField] GameObject canvas301;
    [SerializeField] GameObject canvas302;

    //Late and No Uniform?
    [SerializeField] GameObject canvas401;

    void Update()
    {
        //Different variantion
        //Check if either use car, transport or walk WITH clothes ON/OFF

        //Car
        if(checkWorldState.haveClotheOn && checkWorldState.getOnCar)
        {
            canvas101.SetActive(true);
        }
        else if (checkWorldState.haveClotheOn == false && checkWorldState.getOnCar)
        {
            canvas102.SetActive(true);
        }
        //Walk
        else if (checkWorldState.onTime == false && checkWorldState.haveClotheOn)
        {
            canvas201.SetActive(true);
        }
        else if (checkWorldState.haveClotheOn == false && checkWorldState.onTime == false && checkWorldState.getOnCar == false)
        {
            canvas401.SetActive(true);
        }
        //Transport
        else if (checkWorldState.onTime && checkWorldState.haveClotheOn)
        {
            canvas301.SetActive(true);
        }
        else if (checkWorldState.haveClotheOn == false && checkWorldState.onTime && checkWorldState.getOnCar == false)
        {
            canvas302.SetActive(true);
        }
    }
}
