using UnityEngine;

public class FinalyPrice : MonoBehaviour
{
    [SerializeField] TextTranformations priceText;

    [SerializeField] int platformPrice, technologyPrice;

    private void OnEnable() => GetTechnologyPrice();

    public void GetPlatformPrice(int _platformPrice)
    {
        platformPrice = _platformPrice;
        CalculateGamePrice();
    }

    public void GetTechnologyPrice()
    {
        technologyPrice = Engine.GetEnginePrice();
        CalculateGamePrice();
    }

    void CalculateGamePrice() => priceText.TransformText(platformPrice + technologyPrice);

    public int GetGamePrice()
    {
        return technologyPrice + platformPrice;
    }
}