using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // You need to add this for scene management.

public class SceneFlashEffect : MonoBehaviour
{
    [SerializeField] private Image flashImage; // Ensure you set this reference in the Inspector.
    [SerializeField] private string sceneName = "GameScene"; // Name of the scene you want to load

    private float originalTimeScale;

    private void Start()
    {
        // Assuming you want the flash effect to start immediately for demonstration purposes.
        StartCoroutine(FlashEffect(0.4f, 0.2f, 0.4f, 5));
    }

    private IEnumerator FlashEffect(float fadeInDuration, float fullWhiteDuration, float fadeOutDuration, int repeatTimes)
    {
        // Save the original time scale.
        originalTimeScale = Time.timeScale;
        // Set the time scale to 0, effectively pausing the game.
        Time.timeScale = 0;

        // The initial color is fully transparent.
        Color initialColor = new Color(1f, 1f, 1f, 0f);
        // The final color is fully opaque white.
        Color finalColor = new Color(1f, 1f, 1f, 1f);

        for (int i = 0; i < repeatTimes; i++)
        {
            // Fade in (from 0 to 1 alpha).
            for (float t = 0; t < fadeInDuration; t += Time.unscaledDeltaTime)
            {
                float normalizedTime = t / fadeInDuration;
                flashImage.color = Color.Lerp(initialColor, finalColor, normalizedTime);
                yield return null; // Wait for the next frame.
            }

            flashImage.color = finalColor; // Ensure the color is set to the final value.

            // Stay at full white for the specified duration.
            float whiteStartTime = Time.unscaledTime;
            while (Time.unscaledTime < whiteStartTime + fullWhiteDuration)
            {
                yield return null; // Wait for the next frame.
            }

            // Fade out (from 1 to 0 alpha).
            for (float t = 0; t < fadeOutDuration; t += Time.unscaledDeltaTime)
            {
                float normalizedTime = t / fadeOutDuration;
                flashImage.color = Color.Lerp(finalColor, initialColor, normalizedTime);
                yield return null; // Wait for the next frame.
            }

            flashImage.color = initialColor; // Ensure the color is reset to the initial value.
        }

        // Restore the original time scale, resuming the game.
        Time.timeScale = originalTimeScale;

        // Load the scene after the flash effect is complete.
        SceneManager.LoadScene(sceneName);
    }
}
