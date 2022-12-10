using UnityEngine;
using UnityEngine.UI;

public class StudioInfoWindow : MonoBehaviour
{
    [SerializeField] OfficePresenter officePresenter;

    [SerializeField] OfficeAcquisition acquisition;

    [SerializeField] TextTranformations priceText, paymentText;

    [SerializeField] Image officeImage;

    [SerializeField] Text studioNameText, studioDescriptionText, employeesAmountText;

    private void OnEnable() => priceText.TransformText(officePresenter.office.price);

    public void GetInfoAboutStudio(OfficePresenter officeData, OfficeAcquisition officeAcquisition)
    {
        officePresenter = officeData;
        acquisition = officeAcquisition;

        officeImage.sprite = officePresenter.office.officePhoto;

        studioNameText.text = officePresenter.office.officeName;
        studioDescriptionText.text = officePresenter.office.officeDescription;

        employeesAmountText.text = officePresenter.office.employeesAmount.ToString() + 
            "  Salary : " + officePresenter.Salary() + "/Week";

        paymentText.TransformText(officePresenter.office.weeklyPaymentValue);
    }

    public void BuyStudio() => acquisition.BuyOffice();

    public void ArendStudio() => acquisition.SubscribeToRent();

    public void CloseWindow() => Destroy(gameObject);
}