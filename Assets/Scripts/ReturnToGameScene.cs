using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ReturnToGameScene : MonoBehaviour
{
    public float delay = 5f; // You can adjust this delay if needed
    public string sceneName = "GameScene"; // Name of the scene you want to load

    // This method is public so it can be called from other scripts.
    public IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}

