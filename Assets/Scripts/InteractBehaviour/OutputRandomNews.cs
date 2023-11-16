using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputRandomNews : MonoBehaviour
{
    [SerializeField] GameObject news1;
    [SerializeField] GameObject news2;
    [SerializeField] GameObject news3;

    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(0, 10);

        if (randomNumber <= 3)
        {
            news1.SetActive(true);
        }
        else if (randomNumber <= 6)
        {
            news2.SetActive(true);
        }
        else
        {
            news3.SetActive(true);
        }
    }
}
