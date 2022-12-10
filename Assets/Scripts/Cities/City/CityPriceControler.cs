using UnityEngine;

public class CityPriceControler : MonoBehaviour
{
    [SerializeField] OfficePresenter thisOffice;

    int lastHandledYear = 1980, randomMonth, randomDay;

    private void Start()
    {
        GlobalEvents.OnDateChange.AddListener((day, week, month, year) =>
        {
            if (year != lastHandledYear)
            {
                randomMonth = Random.Range(1, 12);
                randomDay = Random.Range(1, 7);
                lastHandledYear++;

                if (month == randomMonth && day == randomDay) 
                    thisOffice.AddSellPrice(Random.Range((thisOffice.office.price / 100) * 1, (thisOffice.office.price / 100) * 5));
            }
        });
    }
}