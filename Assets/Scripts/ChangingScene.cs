using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangingScene : MonoBehaviour
{
    [SerializeField] bool nextScene;
    [SerializeField] string SceneName;

    //Check if I want to change the camera position instead move to different scene
    public bool changeToDifferentPosition;
    [SerializeField] Camera cameraGameObject;
    [SerializeField] Transform camPosition;

    private void Update()
    {
        if (nextScene && Input.GetKeyDown(KeyCode.E) && !changeToDifferentPosition)
        {
            ChangeDifferentScene();
        }
        else if (nextScene && Input.GetKeyDown(KeyCode.E) && changeToDifferentPosition)
        {
            ChangeCameraToDifferentPosition();
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

    private void ChangeCameraToDifferentPosition()
    {
        cameraGameObject.transform.position = camPosition.transform.position;
    }
}
