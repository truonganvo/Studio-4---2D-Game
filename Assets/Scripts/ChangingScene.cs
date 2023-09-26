using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangingScene : MonoBehaviour
{
    [SerializeField] bool nextScene;
    [SerializeField] string SceneName;

    private void Update()
    {
        if (nextScene && Input.GetKeyDown(KeyCode.E))
        {
            ChangeDifferentScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Pick UP something");
            nextScene = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            nextScene = false;
        }
    }

    private void ChangeDifferentScene()
    {
        SceneManager.LoadScene(SceneName);
        Debug.Log("Load Scene");
    }
}
