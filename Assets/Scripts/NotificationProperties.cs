using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationProperties : MonoBehaviour
{
    private int _notificationId;
    private TMP_Text _titleText;
    private TMP_Text _descriptionText;
    private RawImage _iconRawImage;

    [Header("Notification icon list")]
    [SerializeField] private Texture2D[] _iconArray = null;

    public void InitializeNotificationProperties()
    {
        _titleText = transform.Find("TitleText").GetComponent<TMP_Text>();
        _descriptionText = transform.Find("DescriptionText").GetComponent<TMP_Text>();
        _iconRawImage = transform.Find("IconRawImage").GetComponent<RawImage>();
    }

    public void SetNotificationId(int notificationId) { _notificationId = notificationId; }

    public void SetDescription(string dedscription) { _descriptionText.text = dedscription; }

    public void SetTitle(string title) { _titleText.text = title; }

    public void SetIcon(int iconId) { _iconRawImage.texture = _iconArray[iconId]; }
}
