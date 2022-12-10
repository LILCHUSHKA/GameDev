using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{
    [SerializeField] Text time, date;

    string hour, minute;
    string day, month, year;

    public void SetClockInText()
    {
        TransformClock(DateTime.Now.Hour, DateTime.Now.Minute);
        time.text = hour + ":" + minute;

        TransformDate(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        date.text = day + "." + month + "." + year;
    }

    void TransformClock(int _hour, int _minute)
    {
        hour = _hour.ToString();
        minute = _minute.ToString();

        if (minute.Length == 1) minute = "0" + minute;
        if (hour.Length == 1) hour = "0" + hour;
    }

    void TransformDate(int _day, int _month, int _year)
    {
        day = _day.ToString();
        month = _month.ToString();
        year = _year.ToString();

        if (day.Length == 1) day = "0" + day;
        if (month.Length == 1) month = "0" + month;
    }
}