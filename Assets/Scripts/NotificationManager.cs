using UnityEngine;
using UnityEngine.UI;


public class NotificationManager : MonoBehaviour
{
    [Header("OnClick Buttons")]
    [SerializeField]
    Button _sendButton = null;

    void Start()
    {
        if(_sendButton == null)
        {
            Debug.LogError("NotificationManager requires connecting a send button in the inspector");
            return;
        }

        _sendButton.onClick.AddListener(ScheduleNotifications);
    }

    private void ScheduleNotifications()
    {
        Debug.Log("OnClick: Send notifications");
    }
}
