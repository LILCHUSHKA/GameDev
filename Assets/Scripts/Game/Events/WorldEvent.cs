using UnityEngine;

[System.Serializable]
public class WorldEvent
{
    public string eventName;

    [TextArea(2, 10)] public string eventText;

    public int day, week, month, year;

    [HideInInspector] public bool isDay, isWeek, isMonth, isYear;

    public virtual void ActiveEvent(SwimMessagePanel messagePanel) { }
    public virtual void ActiveEvent() { }
}