using System.Collections.Generic;
using UnityEngine;

public class TechnologyEvents : MonoBehaviour
{
    [SerializeField] List<TechnologyEvent> technologyEvents;

    private void Start() => SubscribeEvent();

    void SubscribeEvent()
    {
        GlobalEvents.OnDateChange.AddListener((eDay, eWeek, eMonth, eYear) =>
        {
            if (eDay == technologyEvents[0].day && technologyEvents[0].isWeek) RemoveEvent();
            if (eWeek == technologyEvents[0].week && technologyEvents[0].isMonth) technologyEvents[0].isWeek = true;
            if (eMonth == technologyEvents[0].month && technologyEvents[0].isYear) technologyEvents[0].isMonth = true;
            if (eYear == technologyEvents[0].year) technologyEvents[0].isYear = true;
        });
    }

    void RemoveEvent()
    {
        UnsubscribeEvent();

        technologyEvents[0].ActiveEvent();
        technologyEvents.RemoveAt(0);

        SubscribeEvent();
    }

    void UnsubscribeEvent()
    {
        GlobalEvents.OnDateChange.RemoveListener((eDay, eWeek, eMonth, eYear) =>
        {
            if (eDay == technologyEvents[0].day && technologyEvents[0].isWeek) RemoveEvent();
            if (eWeek == technologyEvents[0].week && technologyEvents[0].isMonth) technologyEvents[0].isWeek = true;
            if (eMonth == technologyEvents[0].month && technologyEvents[0].isYear) technologyEvents[0].isMonth = true;
            if (eYear == technologyEvents[0].year) technologyEvents[0].isYear = true;
        });
    }
}