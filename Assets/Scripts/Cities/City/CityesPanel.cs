using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityesPanel : MonoBehaviour
{
    [SerializeField] float showDelay = 0.05f;

    [SerializeField] Text sortingNameText;

    public List<OfficePresenter> offices;

    private void OnEnable() => StartCoroutine(ShowCityDelay());

    private void OnDisable()
    {
        ClearCityPanel();
        sortingNameText.text = "";
    }

    void ClearCityPanel()
    {
        foreach (OfficePresenter city in offices)
            city.gameObject.SetActive(false);
    }

    public void ApplySortingByName()
    {
        if (sortingNameText.text != "")
        {
            ClearCityPanel();

            foreach (OfficePresenter city in offices)
            {
                if (city.office.officeName == sortingNameText.text && city.office.canSpawn)
                    city.gameObject.SetActive(true);
            }
        }

        else StartCoroutine(ShowCityDelay());
    }

    public int ReturnFreeOffice()
    {
        bool isAdded = false;

        int freeIndex = 0;

        while (isAdded != true)
        {
            int officeIndex = Random.Range(0, offices.Count - 1);

            if (!offices[officeIndex].office.isPlayerOffice && !offices[officeIndex].office.isBotOffice)
            {
                freeIndex = officeIndex;
                isAdded = true;
            }
        }

        return freeIndex;
    }

    IEnumerator ShowCityDelay()
    {
        foreach (OfficePresenter city in offices)
        {
            yield return new WaitForSecondsRealtime(showDelay);

            if (city.office.canSpawn && !city.office.isBotOffice) city.gameObject.SetActive(true);
        }
    }

    public int BuyedCityesCount()
    {
        int buyedCityesCount = 0;

        foreach (OfficePresenter city in offices)
        {
            if (city.office.isBuy || city.office.isRent)
                buyedCityesCount++;
        }

        return buyedCityesCount;
    }
}