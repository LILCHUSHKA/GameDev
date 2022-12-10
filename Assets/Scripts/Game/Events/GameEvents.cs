using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    [SerializeField] SwimMessagePanel swimMessagePanel;

    [SerializeField] List<GameEvent> gameEvents;

    private void Start() => SubscribeEvent();

    void SubscribeEvent()
    {
        GlobalEvents.OnDateChange.AddListener((eDay, eWeek, eMonth, eYear) =>
            {
                if (eDay == gameEvents[0].day && gameEvents[0].isWeek) RemoveEvent();
                if (eWeek == gameEvents[0].week && gameEvents[0].isMonth) gameEvents[0].isWeek = true;
                if (eMonth == gameEvents[0].month && gameEvents[0].isYear) gameEvents[0].isMonth = true;
                if (eYear == gameEvents[0].year) gameEvents[0].isYear = true;
            });
    }

    void RemoveEvent()
    {
        UnsubscribeEvent();

        gameEvents[0].ActiveEvent(swimMessagePanel);
        gameEvents.RemoveAt(0);

        SubscribeEvent();
    }

    void UnsubscribeEvent()
    {
        GlobalEvents.OnDateChange.RemoveListener((eDay, eWeek, eMonth, eYear) =>
        {
            if (eDay == gameEvents[0].day && gameEvents[0].isWeek) RemoveEvent();
            if (eWeek == gameEvents[0].week && gameEvents[0].isMonth) gameEvents[0].isWeek = true;
            if (eMonth == gameEvents[0].month && gameEvents[0].isYear) gameEvents[0].isMonth = true;
            if (eYear == gameEvents[0].year) gameEvents[0].isYear = true;
        });
    }
}