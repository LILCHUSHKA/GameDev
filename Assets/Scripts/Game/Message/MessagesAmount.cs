using UnityEngine;
using UnityEngine.UI;

public class MessagesAmount : MonoBehaviour
{
    [SerializeField] Text messagesCountText;

    private void OnEnable() => messagesCountText.text = NewMessages();

    private void Start() =>
        GlobalEvents.OnMessageAdd.AddListener(HandleMessageCount);

    public void HandleMessageCount() => messagesCountText.text = NewMessages();

    string NewMessages()
    {
        int newMessages = 0;

        for(int i = 0; i < MessageList.messages.Count; i++)
        {
            if (MessageList.messages[i].isRead == false) newMessages++;
        }

        return newMessages.ToString();
    }
}