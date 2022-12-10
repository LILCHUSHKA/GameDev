using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StockPresenter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] StockState stockState;

    [SerializeField] FavoriteButton favoriteButton;
    
    [SerializeField] Stock stockData;

    [SerializeField] StockInfoPanel stockInfoPanel;

    [SerializeField] Text companyNameText;

    public void GetStockData(Stock stock)
    {
        stockData = stock;

        companyNameText.text = stockData.stockDescription.companyName;
        stockState.GetStockPrice(stockData.stockPrice);

        favoriteButton.gameObject.SetActive(stockData.isTracked);
        favoriteButton.ChangeSprite(stockData.isTracked);
    }

    public void GetAdditonalData(StockInfoPanel _stockInfoPanel) => stockInfoPanel = _stockInfoPanel;

    public void AddToFavorites()
    {
        if (stockData.isTracked == true) stockData.isTracked = false;

        else stockData.isTracked = true;

        favoriteButton.ChangeSprite(stockData.isTracked);
    }

    public void OnPointerEnter(PointerEventData eventData) => favoriteButton.gameObject.SetActive(true);

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!stockData.isTracked)
            favoriteButton.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData) => stockInfoPanel.GetStock(stockData);
}