using UnityEngine;
using UnityEngine.UI;

public class MessagePresenter : MonoBehaviour
{
    [SerializeField] MessageDescriptionPanel descriptionPanel;

    [SerializeField] Text theme, whom;

    [SerializeField] Image image;

    [SerializeField] string description, date;

    int index;

    public void GetMessageData(Message message)
    {
        theme.text = message.theme;
        whom.text = "From whom : " + message.whom;
        description = message.description;
        date = message.date;

        index = message.index;
    }

    public void GetDescriptionPanel(MessageDescriptionPanel panel) => descriptionPanel = panel;

    public void OpenMessageDescription() =>
        descriptionPanel.HandleMessageData(theme.text, description, index, date);

    public void MakeMessageRead()
    {
        MessageList.messages[index].isRead = true;
        ChangeColor(new Color32(255, 255, 255, 107));
    }

    public void ChangeColor(Color32 newColor) => image.color = newColor;
}