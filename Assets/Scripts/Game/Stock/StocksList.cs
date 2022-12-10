using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StocksList : MonoBehaviour
{
    [SerializeField] CityesPanel cityesPanel;

    [SerializeField] StockPresenter stockPresenter;

    [SerializeField] TrackedStockPresenter trackedStockPresenter;

    [SerializeField] StockInfoPanel stockInfoPanel;

    [SerializeField] Transform bag, trackedSharesBag;

    [SerializeField] float spawnDelay;

    [SerializeField] List<Stock> stocks;

    [SerializeField] List<Stock> renderStocks;

    private void Start()
    {
        int randomYear = Random.Range(GameTime.year + 1, GameTime.year + 3);
        int randomMonth = Random.Range(1, 12);
        int randomWeek = Random.Range(1, 4);

        GlobalEvents.OnDateChange.AddListener((day, week, month, year) =>
        {
            if (stocks.Count != 0)
            {
                if (year == randomYear && month == randomMonth && week == randomWeek)
                {
                    AddStock();

                    randomYear = Random.Range(GameTime.year + 1, GameTime.year + 3);
                    randomMonth = Random.Range(1, 12);
                    randomWeek = Random.Range(1, 4);
                }
            }
        });
    }

    public void ClearBag()
    {
        foreach (Transform child in bag) Destroy(child.gameObject);

        foreach (Transform child in trackedSharesBag) Destroy(child.gameObject);
    }

    public void SpawnStocks()
    {
        ClearBag();
        StartCoroutine(SpawnDelay());
    }

    public void SpawnTrackedStocks(GameObject isEmptyMessage)
    {
        foreach (var stock in renderStocks)
        {
            if (stock.isTracked)
            {
                trackedStockPresenter.GetStockData(stock, stockInfoPanel);
                Instantiate(trackedStockPresenter, trackedSharesBag);
            }

            if (trackedSharesBag.childCount == 0) isEmptyMessage.gameObject.SetActive(true);
            else isEmptyMessage.gameObject.SetActive(false);
        }
    }

    public void DeleteRenderStock(int removeIndex) => renderStocks.RemoveAt(removeIndex);

    public void DeleteStock(int removeIndex) => stocks.RemoveAt(removeIndex);

    public void AddStock()
    {
        int index = Random.Range(0, stocks.Count - 1);

        for (int i = 0; i < Random.Range(1, 3); i++)
            stocks[index].stockDescription.AddOffice(cityesPanel.offices[cityesPanel.ReturnFreeOffice()].office);

        stocks[index].stockDescription.FillDescriptionData(this);

        renderStocks.Add(stocks[index]);
        stocks.RemoveAt(index);
    }

    IEnumerator SpawnDelay()
    {
        for (int i = 0; i < renderStocks.Count; i++)
        {
            renderStocks[i].indexInList = i;

            stockPresenter.GetStockData(renderStocks[i]);
            stockPresenter.GetAdditonalData(stockInfoPanel);

            Instantiate(stockPresenter, bag);

            yield return new WaitForSecondsRealtime(spawnDelay);
        }
    }
}