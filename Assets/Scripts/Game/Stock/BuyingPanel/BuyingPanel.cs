using UnityEngine;
using UnityEngine.UI;
using System;

public class BuyingPanel : MonoBehaviour
{
    [SerializeField] StocksList stocksList;

    [SerializeField] Stock stockData;

    [SerializeField] TextTranformations sumText;

    [SerializeField] InputField percentFieldText;

    [SerializeField] Text availableStocksText;

    [SerializeField] GameObject parentPage;

    public void GetStockData(Stock stock)
    {
        stockData = stock;
        availableStocksText.text = stockData.availableStocks.ToString();
    }

    public void DeductPercent()
    {
        int percentValue = Convert.ToInt32(percentFieldText.text);

        if (percentValue > 0)
        {
            percentValue--;
            sumText.TransformText((stockData.stockDescription.sharesAmount / 100) * percentValue * stockData.stockPrice);
        }
        else return;

        percentFieldText.text = percentValue.ToString();
    }

    public void AddPercent()
    {
        int percentValue = Convert.ToInt32(percentFieldText.text);

        if (percentValue < 99) percentValue++;
        else return;

        percentFieldText.text = percentValue.ToString();

        sumText.TransformText((stockData.stockDescription.sharesAmount / 100) * percentValue * stockData.stockPrice);
    }

    public void BuyShares()
    {
        int finalyPrice = (stockData.stockDescription.sharesAmount / 100) * Convert.ToInt32(percentFieldText.text) *
            stockData.stockPrice;

        if (finalyPrice != 0)
        {
            if (ActionPanel.GetMoneyAmount() >= finalyPrice)
            {
                stockData.availableStocks -= Convert.ToInt32(percentFieldText.text);
                ActionPanel.TakeMoney(finalyPrice);
            }

            availableStocksText.text = stockData.availableStocks.ToString();
        }

        if (stockData.availableStocks < 71)
        {
            foreach (var office in stockData.stockDescription.offices) office.OnActiveIndependent.Invoke();

            stockData.stockDescription.bankruptcyYear = 0;
            stocksList.DeleteRenderStock(stockData.indexInList);
            parentPage.SetActive(false);
        }
    }

    public void BuyCompany()
    {
        if (ActionPanel.GetMoneyAmount() >= stockData.stockDescription.costPrice)
        {
            ActionPanel.TakeMoney(stockData.stockDescription.costPrice);

            stockData.stockDescription.bankruptcyYear = 0;
            stocksList.DeleteRenderStock(stockData.indexInList);
            parentPage.SetActive(false);

            foreach (var office in stockData.stockDescription.offices)
            {
                office.isBotOffice = false;
                office.isPlayerOffice = true;
            }
        }
    }
}