using UnityEngine;
using UnityEngine.UI;

public class AcceptPanel : MonoBehaviour
{
    [SerializeField] OfficeAcquisition officeAcquisition;

    [SerializeField] Text acceptDescription;

    [SerializeField] Button sellButton, rentButton;

    private void OnDisable()
    {
        sellButton.gameObject.SetActive(false);
        rentButton.gameObject.SetActive(false);
    }

    public void ShowWindow(string description, string acceptType)
    {
        acceptDescription.text = description;

        if (acceptType == "Sell") sellButton.gameObject.SetActive(true);
        else if (acceptType == "Rent") rentButton.gameObject.SetActive(true);
    }

    public void Sell() => officeAcquisition.SellOffice();

    public void Unsubscribe() => officeAcquisition.UnsubscribeToRent();
}