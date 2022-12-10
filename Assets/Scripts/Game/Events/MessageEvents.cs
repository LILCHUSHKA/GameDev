using System.Collections.Generic;
using UnityEngine;

public class MessageEvents : MonoBehaviour
{
    [SerializeField] MessageList messageList;

    [SerializeField] List<MessageEvent> messageEvents;

    private void Start() => SubscribeEvent();

    void SubscribeEvent()
    {
        GlobalEvents.OnDateChange.AddListener((eDay, eWeek, eMonth, eYear) =>
        {
            if (eDay == messageEvents[0].day && messageEvents[0].isWeek) RemoveEvent();
            if (eWeek == messageEvents[0].week && messageEvents[0].isMonth) messageEvents[0].isWeek = true;
            if (eMonth == messageEvents[0].month && messageEvents[0].isYear) messageEvents[0].isMonth = true;
            if (eYear == messageEvents[0].year) messageEvents[0].isYear = true;
        });
    }

    void RemoveEvent()
    {
        UnsubscribeEvent();

        messageEvents[0].ActiveEvent();

        messageEvents.RemoveAt(0);

        SubscribeEvent();
    }

    void UnsubscribeEvent()
    {
        GlobalEvents.OnDateChange.RemoveListener((eDay, eWeek, eMonth, eYear) =>
        {
            if (eDay == messageEvents[0].day && messageEvents[0].isWeek) RemoveEvent();
            if (eWeek == messageEvents[0].week && messageEvents[0].isMonth) messageEvents[0].isWeek = true;
            if (eMonth == messageEvents[0].month && messageEvents[0].isYear) messageEvents[0].isMonth = true;
            if (eYear == messageEvents[0].year) messageEvents[0].isYear = true;
        });
    }
}