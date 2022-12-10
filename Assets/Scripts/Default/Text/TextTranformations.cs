using UnityEngine;
using UnityEngine.UI;

public class TextTranformations : MonoBehaviour
{
    [SerializeField] Text thisText;

    private void Awake() => thisText = GetComponent<Text>();

    public void TransformText(int intValue)
    {
        thisText.text = 
            intValue.ToString();

        switch (thisText.text.Length + 1)
        {
            case 5: GetSmallValue('K');
                break;
            case 6:
                GetMiddleValue('K');
                break;
            case 7:
                GetHightValue('K');
                break;
            case 8:
                GetSmallValue('M');
                break;
            case 9:
                GetMiddleValue('M');
                break;
            case 10:
                GetHightValue('M');
                break;
            case 11:
                GetSmallValue('B');
                break;
            case 12:
                GetMiddleValue('B');
                break;
            case 13:
                GetHightValue('B');
                break;
        }
    }

    string GetSmallValue(char symbol)
    {
        return thisText.text = (thisText.text[0].ToString() + "." + thisText.text[1].ToString() + symbol.ToString());
    }

    string GetMiddleValue(char symbol)
    {
        return thisText.text = (thisText.text[0].ToString() + thisText.text[1].ToString() + "." + thisText.text[2].ToString() + symbol.ToString());
    }

    string GetHightValue(char symbol)
    {
        return thisText.text = (thisText.text[0].ToString() + thisText.text[1].ToString() + thisText.text[2].ToString() + "." + thisText.text[3].ToString() + symbol.ToString());
    }
}