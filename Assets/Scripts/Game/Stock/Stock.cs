using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "New stock")]
public class Stock : ScriptableObject
{
    [HideInInspector] public UnityEvent<int> OnStockPriceChanged = new UnityEvent<int>();

    public StockDescription stockDescription;

    [Space(20)]
    public int stockPrice;
    public int startPrice;

    public int availableStocks = 100;

    public int indexInList = 0, maxPrice = 0, minPrice = 0;

    public bool isTracked = false;

    public List<int> lastValues;

    private void OnEnable()
    {
        GlobalEvents.OnDateChange.AddListener((day, week, month, year) =>
        {
            if (day == 1) ChangePrice();

            if (year == stockDescription.bankruptcyYear && month == stockDescription.bankruptcyMonth && week == stockDescription.bankruptcyWeek)
            {
                stockDescription.stocksList.DeleteStock(indexInList);

                foreach (var item in stockDescription.offices)
                    item.isBotOffice = false;
            }
        });
    }

    void ChangePrice()
    {
        int random = Random.Range(0, 10);

        if (random > 5) stockPrice += Random.Range(1, 4);
        else stockPrice -= Random.Range(1, 2);

        if (stockPrice < 1) stockPrice = 1;

        if (lastValues.Count > 200) lastValues.RemoveAt(0);

        lastValues.Add(stockPrice);

        if (stockPrice > maxPrice) maxPrice = stockPrice;
        if (stockPrice < minPrice) minPrice = stockPrice;

        OnStockPriceChanged.Invoke(stockPrice);
    }
}

[System.Serializable]
public class StockDescription
{
    public StocksList stocksList { get; private set; }

    public string companyName;

    [Space(10)] [TextArea(5, 10)] public string companyDescription = string.Empty;

    public string managerName, date;

    public int sharesAmount, costPrice, employeesAmount;

    public int bankruptcyYear, bankruptcyMonth, bankruptcyWeek;

    public List<Office> offices = new List<Office>();

    public void AddOffice(Office addedOffice)
    {
        offices.Add(addedOffice);
        addedOffice.isBotOffice = true;
    }

    public void FillDescriptionData(StocksList _stocks)
    {
        stocksList = _stocks;

        managerName = offices[0].countryNames[Random.Range(0, offices[0].countryNames.Count - 1)];
        date = GameTime.year.ToString();

        sharesAmount = Random.Range(100000, 1000000);
        costPrice = Random.Range(10000000, 100000000) * offices.Count;

        bankruptcyYear = Random.Range(GameTime.year + 15, GameTime.year + 50);
        bankruptcyMonth = Random.Range(1, 12);
        bankruptcyWeek = Random.Range(1, 4);

        foreach (var item in offices)
            employeesAmount += item.employeesAmount;
    }
}