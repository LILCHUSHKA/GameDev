using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrackedStockPresenter : MonoBehaviour, IPointerExitHandler
{
    [SerializeField] Stock stockData;

    [SerializeField] StockInfoPanel infoPanel;

    [SerializeField] FavoriteButton favoriteButton;

    [SerializeField] Text companyNameText, stockPriceText;

    private void OnDestroy() =>
        stockData.OnStockPriceChanged.RemoveListener(price => stockPriceText.text = price.ToString());

    private void Start()
    {
        stockData.OnStockPriceChanged.AddListener(price => stockPriceText.text = price.ToString());

        companyNameText.text = stockData.stockDescription.companyName;
        stockPriceText.text = stockData.stockPrice.ToString();
    }

    public void GetStockData(Stock stock, StockInfoPanel stockInfoPanel)
    {
        stockData = stock;
        infoPanel = stockInfoPanel;
    }

    public void OpenStockInfo() => infoPanel.GetStock(stockData);

    public void UpdateTracked()
    {
        if (stockData.isTracked == false) stockData.isTracked = true;

        else stockData.isTracked = false;

        favoriteButton.ChangeSprite(stockData.isTracked);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (stockData.isTracked == false) Destroy(gameObject);
    }
}