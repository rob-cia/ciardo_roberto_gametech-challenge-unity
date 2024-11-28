using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationProperties : MonoBehaviour
{
    private const int NULL_ID = -1;

    public int _notificationId;
    private TMP_Text _titleText;
    private TMP_Text _descriptionText;
    private RawImage _iconRawImage;
    private Button _removeNotificationButton;
    private int _order;

    [Header("Notification icon list")]
    [SerializeField] private Texture2D[] _iconArray = null;

    public void InitializedNotificationProperties()
    {
        _notificationId = NULL_ID;
        _titleText = transform.Find("TitleText").GetComponent<TMP_Text>();
        _descriptionText = transform.Find("DescriptionText").GetComponent<TMP_Text>();
        _iconRawImage = transform.Find("IconBackground/IconRawImage").GetComponent<RawImage>();
        _removeNotificationButton = transform.Find("DeleteButton").GetComponent<Button>();
        _order = NULL_ID;

        // test
        SetTitle(transform.gameObject.name);
        _removeNotificationButton.onClick.AddListener(OnButtonClickRemoveNotification);
    }

    public void SetNotificationId(int notificationId) { _notificationId = notificationId; }

    public void SetDescription(string dedscription) { _descriptionText.text = dedscription; }

    public void SetTitle(string title) { _titleText.text = title; }

    public void SetIcon(int iconId) { _iconRawImage.texture = _iconArray[iconId]; }

    // Unity-Remove-Scheduled-Notification
    public void OnButtonClickRemoveNotification()
    {
        if (_notificationId == NULL_ID) { return; }

        //Debug.Log("OnButtonClickRemoveNotification " + _notificationId);

        using (AndroidJavaClass notificationPlugin = new AndroidJavaClass("com.rc.ciardo_roberto_gametech_challenge_android.NotificationPlugin"))
        {
            notificationPlugin.CallStatic("removeNotificationById", GetUnityActivity(), _notificationId);
        }
    }

    private AndroidJavaObject GetUnityActivity()
    {
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }
    }

    // Unity-Change-Notifications-Schedule
    public void SetOrder(int order) { _order = order; }
    public int GetOrder() { return _order; }
    
}
