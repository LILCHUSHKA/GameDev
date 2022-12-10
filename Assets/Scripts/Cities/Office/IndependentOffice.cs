using UnityEngine;

public class IndependentOffice : MonoBehaviour
{
    OfficePresenter thisOffice;

    private void Awake() => thisOffice = gameObject.GetComponent<OfficePresenter>();

    private void Start()
    {
        int randomYear = Random.Range(GameTime.year, GameTime.year + 1);
        int randomMonth = Random.Range(1, 12);
        int randomWeek = Random.Range(1, 4);

        GlobalEvents.OnDateChange.AddListener((day, week, month, year) =>
        {
            if (year == randomYear && month == randomMonth && week == randomWeek)
            {
                RequestsPanel.AddIndependentGameRequest(thisOffice);

                randomYear = Random.Range(GameTime.year, GameTime.year + 1);
                randomMonth = Random.Range(1, 12);
                randomWeek = Random.Range(1, 4);
            }
        });
    }
}