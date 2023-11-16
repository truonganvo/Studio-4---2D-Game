using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour
{
    [SerializeField] string levelName;
    [SerializeField] Image flashImage;
    [SerializeField] GameObject canvasWithImage; // Reference to the canvas with the image

    private bool isPlayerNear = false;
    private int interactionCount = 0;
    private bool isFlashActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNear && !isFlashActive)
        {
            interactionCount++;
            Debug.Log($"Interacted with bed {interactionCount} times.");

            // Start the flash effect coroutine with a 2.5-second duration.
            StartCoroutine(FlashEffect(2f));

            if (interactionCount == 3)
            {
                StartCoroutine(ShowImageAndChangeScene());
            }
        }
    }

    private IEnumerator FlashEffect(float duration)
    {
        isFlashActive = true;

        // Save the original time scale.
        float originalTimeScale = Time.timeScale;
        // Set the time scale to 0, effectively pausing the game.
        Time.timeScale = 0;

        // Calculate duration for the fade-in and fade-out effects.
        float fadeDuration = duration / 2;

        // The initial color is fully transparent.
        Color initialColor = new Color(1f, 1f, 1f, 0f);
        // The final color is fully opaque white.
        Color finalColor = new Color(1f, 1f, 1f, 1f);

        // Fade in (from 0 to 1 alpha).
        for (float t = 0; t < fadeDuration; t += Time.unscaledDeltaTime)
        {
            float normalizedTime = t / fadeDuration;
            flashImage.color = Color.Lerp(initialColor, finalColor, normalizedTime);
            yield return null;
        }

        flashImage.color = finalColor;

        // Wait for the duration of the flash effect.
        yield return new WaitForSecondsRealtime(duration);

        // Fade out (from 1 to 0 alpha).
        for (float t = 0; t < fadeDuration; t += Time.unscaledDeltaTime)
        {
            float normalizedTime = t / fadeDuration;
            flashImage.color = Color.Lerp(finalColor, initialColor, normalizedTime);
            yield return null;
        }

        flashImage.color = initialColor;

        // Restore the original time scale, resuming the game.
        Time.timeScale = originalTimeScale;

        isFlashActive = false;
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

    private IEnumerator ShowImageAndChangeScene()
    {

        yield return new WaitForSeconds(0.5f);
        // Enable the canvas with the image
        canvasWithImage.SetActive(true);

        // Wait for another 5 seconds (you can adjust this duration)
        yield return new WaitForSeconds(1.5f);

        // Load the ending scene
        SceneManager.LoadScene(levelName);
    }
}
