using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour
{
    [SerializeField] string levelName;
    [SerializeField] Image flashImage;
    private bool isPlayerNear = false;
    private int interactionCount = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNear)
        {
            interactionCount++;
            Debug.Log($"Interacted with bed {interactionCount} times.");

            // Start the flash effect coroutine.
            StartCoroutine(FlashEffect(1.0f)); // 1.0f here represents the duration of the effect.

            if (interactionCount == 7)
            {
                Debug.Log("Loading the next scene after 5 interactions with the bed.");
                SceneManager.LoadScene(levelName);
            }
        }
    }

    private IEnumerator FlashEffect(float duration)
    {
        // Save the original time scale.
        float originalTimeScale = Time.timeScale;
        // Set the time scale to 0, effectively pausing the game.
        Time.timeScale = 0;

        float halfDuration = duration / 2;

        // The initial color is fully transparent.
        Color initialColor = new Color(1f, 1f, 1f, 0f);
        // The final color is fully opaque white.
        Color finalColor = new Color(1f, 1f, 1f, 1f);

        // Fade in (from 0 to 1 alpha).
        for (float t = 0; t < halfDuration; t += Time.unscaledDeltaTime)
        {
            float normalizedTime = t / halfDuration;
            flashImage.color = Color.Lerp(initialColor, finalColor, normalizedTime);
            yield return null;
        }

        flashImage.color = finalColor;

        // Fade out (from 1 to 0 alpha).
        for (float t = 0; t < halfDuration; t += Time.unscaledDeltaTime)
        {
            float normalizedTime = t / halfDuration;
            flashImage.color = Color.Lerp(finalColor, initialColor, normalizedTime);
            yield return null;
        }

        flashImage.color = initialColor;

        // Restore the original time scale, resuming the game.
        Time.timeScale = originalTimeScale;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Player is near the bed.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Player has left the bed.");
        }
    }
}
