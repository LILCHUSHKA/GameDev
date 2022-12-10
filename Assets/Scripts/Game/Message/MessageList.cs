using System.Collections.Generic;
using UnityEngine;

public class MessageList : MonoBehaviour
{
    public static List<Message> messages { get; private set; } = new List<Message>();
    
    public static void AddMessage(string _theme, string _messageText, string _whom) 
    {
        Message newMessage = new Message();

        newMessage.theme = _theme;
        newMessage.description = _messageText;
        newMessage.whom = _whom;

        messages.Add(newMessage);

        GlobalEvents.OnMessageAdd.Invoke();
    }
}