using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationReceiver : MonoBehaviour
{
    [SerializeField]
    private TMP_Text titleText;
    [SerializeField]
    private TMP_Text descriptionText;
    [SerializeField]
    private RawImage iconImage;

    [SerializeField]
    private Texture2D[] iconArray;


    void Start()
    {
        string title = GetNotificationData("title");
        string description = GetNotificationData("description");
        string icon = GetNotificationData("icon");

        if (!string.IsNullOrEmpty(title))
        {
            titleText.text = "Titolo: " + title;
        }

        if (!string.IsNullOrEmpty(description))
        {
            descriptionText.text = "Descrizione: " + description;
        }

        if (!string.IsNullOrEmpty(icon))
        {
            iconImage.texture = iconArray[int.Parse(icon)];
        }
    }

    private string GetNotificationData(string key)
    {

        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                using (AndroidJavaObject intent = currentActivity.Call<AndroidJavaObject>("getIntent"))
                {
                    if (intent != null)
                    {
                        return intent.Call<string>("getStringExtra", key);
                    }
                }
            }
        }
        return null;
    }
}
