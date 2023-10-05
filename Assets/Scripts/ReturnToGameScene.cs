using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ReturnToGameScene : MonoBehaviour
{
    public float delay = 10f; // You can adjust this delay if needed
    public string sceneName = "GameScene"; // Name of the scene you want to load

    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
