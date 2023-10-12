using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputRandomNews : MonoBehaviour
{
    [SerializeField] int randomNumber;

    [SerializeField] GameObject news1;
    [SerializeField] GameObject news2;

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(0, 10);
        if(randomNumber <= 3)
        {
            news1.SetActive(true);
        }
        else if(randomNumber >= 3)
        {
            news2.SetActive(true);
        }
    }
}
