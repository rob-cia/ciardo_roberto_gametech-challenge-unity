using UnityEngine;
using UnityEngine.UI;


public class NotificationManager : MonoBehaviour
{
    [Header("OnClick Buttons")]
    [SerializeField]
    Button _sendButton = null;
    [SerializeField]
    Button _removeButton = null;

    [Header("Notification diplayed")]
    [SerializeField] private NotificationProperties[] _notificationProperties;

    void Start()
    {
        if(_sendButton == null)
        {
            Debug.LogError("NotificationManager requires connecting a send button in the inspector");
            return;
        }
        if(_removeButton == null)
        {
            Debug.LogError("NotificationManager requires connecting a remove button in the inspector");
            return;
        }

        _sendButton.onClick.AddListener(ScheduleNotifications);
        _removeButton.onClick.AddListener(RemoveNotifications);

        InitializedNotificationProperties();
    }

    void Update()
    {
        UpdateNotificatioUI();
    }

    private void UpdateNotificatioUI()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            using (AndroidJavaClass notificationPlugin = new AndroidJavaClass("com.rc.ciardo_roberto_gametech_challenge_android.NotificationPlugin"))
            {
                string[] notifications = notificationPlugin.CallStatic<string[]>("getScheduledNotifications", GetUnityActivity());

                for (int i = 0; i < notifications.Length; i++)
                {
                    // Extract notification information
                    string[] notificationData = notifications[i].Split(':');

                    _notificationProperties[i].SetNotificationId(int.Parse(notificationData[0]));
                    _notificationProperties[i].SetTitle(notificationData[1]);
                    _notificationProperties[i].SetDescription(notificationData[2]);
                    
                    long triggerTime = long.Parse(notificationData[3]);

                    // Get the current time in milliseconds since January 1, 1970 (like System.currentTimeMillis in Android)
                    long currentTimeMillis = System.DateTime.UtcNow.Ticks / System.TimeSpan.TicksPerMillisecond - 62135596800000L; // Convert from Ticks to milliseconds, but subtract the DateTime epoch

                    if (triggerTime <= currentTimeMillis)
                    {
                        _notificationProperties[i].gameObject.SetActive(false);
                    }
                    else
                    {
                        _notificationProperties[i].gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    private void InitializedNotificationProperties()
    {
        foreach (NotificationProperties notification in _notificationProperties) { notification.InitializedNotificationProperties(); }
    }

    private void ScheduleNotifications()
    {
        Debug.Log("OnClick: Send notifications");

        if (Application.platform == RuntimePlatform.Android)
        {
            using (AndroidJavaClass notificationPlugin = new AndroidJavaClass("com.rc.ciardo_roberto_gametech_challenge_android.NotificationPlugin"))
            {
                notificationPlugin.CallStatic("scheduleNotifications", GetUnityActivity());
            }
        }
    }

    private void RemoveNotifications()
    {
        Debug.Log("OnClick: Remove notifications");

        if(Application.platform == RuntimePlatform.Android)
        {
            using (AndroidJavaClass notificationPlugin = new AndroidJavaClass("com.rc.ciardo_roberto_gametech_challenge_android.NotificationPlugin"))
            {
                notificationPlugin.CallStatic("removeNotifications", GetUnityActivity());
            }
        }
    }

    private AndroidJavaObject GetUnityActivity()
    {
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }
    }
}
