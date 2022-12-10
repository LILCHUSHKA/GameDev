using UnityEngine;
using UnityEngine.UI;

public class StockState : MonoBehaviour
{
    [SerializeField] TextTranformations stockPriceText;

    [SerializeField] Image stockStateImage;

    [SerializeField] Sprite stockArrowDown, stockArrowUp;

    int lastPrice;

    public void GetStockPrice(int newPrice)
    {
        stockPriceText.TransformText(newPrice);

        if (newPrice > lastPrice)
            stockStateImage.sprite = stockArrowUp;

        else stockStateImage.sprite = stockArrowDown;

        lastPrice = newPrice;
    }
}