using UnityEngine;

public class OfficeAcquisition : MonoBehaviour
{
    [SerializeField] OfficePresenter officePresenter;

    public void BuyOffice()
    {
        if (officePresenter.IsAvailability())
        {
            ActionPanel.TakeMoney(officePresenter.office.price);
            GlobalEvents.OnPlayerBuyStudio.Invoke(officePresenter.office.officeName);

            officePresenter.ChangeColor(Color.blue);

            officePresenter.office.isBuy = true;
            officePresenter.office.isPlayerOffice = true;
        }
    }

    public void SellOffice()
    {
        ActionPanel.AddMoney((int)(officePresenter.office.price / 1.5f));

        if (officePresenter.IsAvailability()) officePresenter.ChangeColor(Color.green);
        else officePresenter.ChangeColor(Color.red);

        officePresenter.office.isBuy = false;
        officePresenter.office.isPlayerOffice = false;
    }

    public void SubscribeToRent()
    {
        WeeklyPayment.AddPaymentValue(officePresenter.office.weeklyPaymentValue);

        officePresenter.ChangeColor(Color.blue);

        officePresenter.office.isRent = true;
        officePresenter.office.isPlayerOffice = true;
    }

    public void UnsubscribeToRent()
    {
        WeeklyPayment.DecreasePaymentValue(officePresenter.office.weeklyPaymentValue);

        if (officePresenter.IsAvailability()) officePresenter.ChangeColor(Color.green);
        else officePresenter.ChangeColor(Color.red);

        officePresenter.office.isRent = false;
        officePresenter.office.isPlayerOffice = false;
    }
}