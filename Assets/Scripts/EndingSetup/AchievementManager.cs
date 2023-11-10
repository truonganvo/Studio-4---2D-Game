using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance { get; private set; }

    public GameObject achievementNotificationPrefab;
    public Canvas canvas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockAchievement(string achievementID)
    {
        if (!PlayerPrefs.HasKey(achievementID))
        {
            PlayerPrefs.SetInt(achievementID, 1);
            ShowAchievementNotification(achievementID);
        }
    }

    private void ShowAchievementNotification(string achievementID)
    {
        GameObject notification = Instantiate(achievementNotificationPrefab, canvas.transform);
        notification.GetComponentInChildren<Text>().text = "Achievement Unlocked: " + achievementID;
        // Destroy notification after some time
        Destroy(notification, 5f);
    }
}




