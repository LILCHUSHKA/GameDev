using System.Collections.Generic;
using UnityEngine;

public class InfoEvents : MonoBehaviour
{
    [SerializeField] SwimMessagePanel swimMessagePanel;
    [SerializeField] GameTime time;

    [SerializeField] List<InfoEvent> infoEvents;

    private void Start() => SubscribeEvent();

    void SubscribeEvent()
    {
        GlobalEvents.OnDateChange.AddListener((eDay, eWeek, eMonth, eYear) =>
        {
            if (eDay == infoEvents[0].day && infoEvents[0].isWeek) RemoveEvent();
            if (eWeek == infoEvents[0].week && infoEvents[0].isMonth) infoEvents[0].isWeek = true;
            if (eMonth == infoEvents[0].month && infoEvents[0].isYear) infoEvents[0].isMonth = true;
            if (eYear == infoEvents[0].year) infoEvents[0].isYear = true;
        });
    }

    void RemoveEvent()
    {
        UnsubscribeEvent();

        infoEvents[0].ActiveEvent(swimMessagePanel);
        infoEvents.RemoveAt(0);

        SubscribeEvent();
    }

    void UnsubscribeEvent()
    {
        GlobalEvents.OnDateChange.RemoveListener((eDay, eWeek, eMonth, eYear) =>
        {
            if (eDay == infoEvents[0].day && infoEvents[0].isWeek) RemoveEvent();
            if (eWeek == infoEvents[0].week && infoEvents[0].isMonth) infoEvents[0].isWeek = true;
            if (eMonth == infoEvents[0].month && infoEvents[0].isYear) infoEvents[0].isMonth = true;
            if (eYear == infoEvents[0].year) infoEvents[0].isYear = true;
        });
    }
}