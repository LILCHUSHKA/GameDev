[System.Serializable]
public class InfoEvent : WorldEvent
{
    public override void ActiveEvent(SwimMessagePanel messagePanel)
    {
        base.ActiveEvent(messagePanel);
        messagePanel.SpawnMessage(eventName + " : " + eventText);
    }
}