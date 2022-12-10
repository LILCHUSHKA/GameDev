using UnityEngine;

[System.Serializable]
public class Profit
{
    public int startProfitValue, profitValue;

    public int DeductProfit()
    {
        return profitValue = Mathf.RoundToInt(profitValue / Random.Range(1, 1.4f));
    }
}