using UnityEngine;
using UnityEngine.UI;

public class MessageDescriptionPanel : MonoBehaviour
{
    [SerializeField] GameObject messageList;
    [SerializeField] Text themeText, descriptionText, dateText;

    int index;

    public void HandleMessageData(string theme, string description, int _index, string _date)
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true);

        themeText.text = theme;
        descriptionText.text = description;
        dateText.text = _date;

        index = _index;
    }

    public void DeleteMessage()
    {
        MessageList.messages.RemoveAt(index);

        messageList.SetActive(false);
        messageList.SetActive(true);

        gameObject.SetActive(false);
    }

}