using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationReceiver : MonoBehaviour
{
    [Header("Notification displayed")]
    [SerializeField]
    private TMP_Text _titleText;
    [SerializeField]
    private TMP_Text _descriptionText;
    [SerializeField]
    private RawImage _iconImage;

    [Header("Notification icon list")]
    [SerializeField]
    private Texture2D[] _iconArray = null;


    void Start()
    {
        if (!CheckInspectorParameterIsCorrect()) 
            return;

        string title = GetNotificationData("title");
        string description = GetNotificationData("description");
        string icon = GetNotificationData("icon");

        if (!string.IsNullOrEmpty(title))
        {
            _titleText.text = "Titolo: " + title;
        }

        if (!string.IsNullOrEmpty(description))
        {
            _descriptionText.text = "Descrizione: " + description;
        }

        if (!string.IsNullOrEmpty(icon))
        {
            _iconImage.texture = _iconArray[int.Parse(icon)];
        }
    }

    private bool CheckInspectorParameterIsCorrect()
    {
        if (_titleText == null)
        {
            Debug.LogError("NotificationReceiver requires connecting a title text in the inspector");
            return false;
        }
        if (_descriptionText == null)
        {
            Debug.LogError("NotificationReceiver requires connecting a description text in the inspector");
            return false;
        }
        if (_iconImage == null)
        {
            Debug.LogError("NotificationReceiver requires connecting an icon rawImage in the inspector");
            return false;
        }
        return true;
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
