using System.Collections.Generic;

[System.Serializable]
public class MessageEvent : WorldEvent
{
    public Message message;

    void SendMessage()
    {
        MessageList.AddMessage(message.theme, message.description, message.whom);
        MessageList.messages[MessageList.messages.Count - 1].GetMessageData(message.theme, message.whom, message.description, GameTime.GetDate());
    }

    public override void ActiveEvent() => SendMessage();
}