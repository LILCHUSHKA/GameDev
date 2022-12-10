using UnityEngine;
using UnityEngine.UI;

public class StockInfoPanel : MonoBehaviour
{
    [SerializeField] StockState stockState;

    [SerializeField] FavoriteButton favoriteButton;

    [SerializeField] StockGraph graph;

    [SerializeField] OfficesPanel officesPanel;

    [SerializeField] BuyingPanel buyingPanel;

    [SerializeField] Stock stockData;

    [SerializeField] Text linkText, companyNameText;

    [SerializeField] GameObject parent;

    [SerializeField] PanelsData panelsData;

    //“ест, потому что € пока не знаю, где будет сайт
    [Header("Test")] [SerializeField] GameObject testParent;

    private void OnDisable()
    {
        stockData.OnStockPriceChanged.RemoveListener(price =>
        {
            stockState.GetStockPrice(price);
            graph.ShowGraph(stockData.lastValues);
        });
    }

    public void GetStock(Stock stock)
    {
        stockData = stock;
        RenderStockInfo();
    }

    void RenderStockInfo()
    {
        graph.ShowGraph(stockData.lastValues);

        favoriteButton.ChangeSprite(stockData.isTracked);

        linkText.text += "/" + stockData.stockDescription.companyName;
        companyNameText.text = stockData.stockDescription.companyName;

        officesPanel.RenderOffices(stockData.stockDescription.offices);
        buyingPanel.GetStockData(stockData);

        FillPanelsText();

        testParent.SetActive(true);
        parent.SetActive(true);
        gameObject.SetActive(true);

        stockData.OnStockPriceChanged.AddListener(price =>
        {
            stockState.GetStockPrice(price);
            graph.ShowGraph(stockData.lastValues);
        });
    }

    void FillPanelsText()
    {
        panelsData.capitalizationText.TransformText(Mathf.Abs(stockData.stockDescription.sharesAmount * stockData.stockPrice));
        panelsData.sharesText.TransformText(stockData.stockDescription.sharesAmount);
        panelsData.costText.TransformText(stockData.stockDescription.costPrice);

        panelsData.minText.text = stockData.minPrice.ToString();
        panelsData.maxText.text = stockData.maxPrice.ToString();
        panelsData.employeesText.text = stockData.stockDescription.employeesAmount.ToString();

        panelsData.descriptionText.text = stockData.stockDescription.companyDescription;
        panelsData.dateText.text = stockData.stockDescription.date;
        panelsData.managerText.text = stockData.stockDescription.managerName;
        panelsData.mainOfficeText.text = stockData.stockDescription.offices[0].officeName;
    }
}

[System.Serializable]
public class PanelsData
{
    public TextTranformations capitalizationText, sharesText, costText;

    public Text minText, maxText;
    public Text descriptionText, employeesText, dateText, managerText, mainOfficeText;
}