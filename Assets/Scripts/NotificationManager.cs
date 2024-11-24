using UnityEngine;
using UnityEngine.UI;


public class NotificationManager : MonoBehaviour
{
    [Header("OnClick Buttons")]
    [SerializeField]
    Button _sendButton = null;
    [SerializeField]
    Button _removeButton = null;

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
