using UnityEngine;

public class RandomCityHandler : MonoBehaviour
{
    [SerializeField] CityesPanel cityesPanel;

    bool messageIsSend = false;

    int targetIndex, targetMonth = 11;

    private void Start()
    {
        GlobalEvents.OnDateChange.AddListener((day, week, month, year) =>
        {
            if (targetMonth != month)
            {
                targetMonth = month;
                HandleRandomCity();
            }
        });
    }

    void HandleRandomCity()
    {
        int randomIndex = Random.Range(0, cityesPanel.offices.Count);

        if (cityesPanel.offices[randomIndex].office.canSpawn && cityesPanel.offices[targetIndex].office.isRent
            && !messageIsSend)
        {
            messageIsSend = true;
            targetIndex = randomIndex;

            MessageList.AddMessage("Rent", "Hi, we are pleased to inform you that the building (" + cityesPanel.offices[targetIndex].office.officeName +
                ") you are renting will become unavailable in a week for a while. " +
                "To avoid this, you can purchase this building!", "Owner");

            return;
        }

        if (cityesPanel.offices[targetIndex].office.canSpawn && !cityesPanel.offices[targetIndex].office.isBuy)
            cityesPanel.offices[targetIndex].office.canSpawn = false;

        else if (!cityesPanel.offices[targetIndex].office.canSpawn && !cityesPanel.offices[targetIndex].office.isBotOffice)
            cityesPanel.offices[targetIndex].office.canSpawn = true;

        else if (cityesPanel.offices[targetIndex].office.canSpawn && cityesPanel.offices[targetIndex].office.isRent)
        {
            cityesPanel.offices[targetIndex].GetComponent<OfficeAcquisition>().UnsubscribeToRent();
            cityesPanel.offices[targetIndex].office.canSpawn = false;
        }

        messageIsSend = false;
    }
}