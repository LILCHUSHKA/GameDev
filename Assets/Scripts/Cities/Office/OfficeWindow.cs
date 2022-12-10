using UnityEngine;
using UnityEngine.UI;

public class OfficeWindow : MonoBehaviour
{
    [SerializeField] RequestCity requestCity;

    [SerializeField] OfficePresenter officePresenter;

    [SerializeField] OfficeAcquisition acquisition;

    [SerializeField] TextTranformations salaryText, weeklyPaymentText, sellPriceText;

    [SerializeField] AcceptPanel acceptPanel;

    [SerializeField] Text employyesText, releasedGamesText, engineUpdateDateText, officeNameText;

    [SerializeField] Image officePhoto, gameRequestButtonImage;

    [SerializeField] Sprite lockSprite, unlockSprite;

    [SerializeField] Button sellButton, rentButton, buyButton, gameRequestButton;

    [SerializeField] Transform bag;

    [SerializeField] Animator animator;

    private void OnEnable()
    {
        if (officePresenter.office.isBuy)
        {
            sellButton.gameObject.SetActive(true);
            sellPriceText.gameObject.SetActive(true);
        }

        if (officePresenter.office.isRent)
        {
            rentButton.gameObject.SetActive(true);
            weeklyPaymentText.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(true);

            sellPriceText.TransformText(officePresenter.office.price);
        }

        CheckGameRequest();
    }

    private void OnDisable()
    {
        rentButton.gameObject.SetActive(false);
        weeklyPaymentText.gameObject.SetActive(false);
        buyButton.gameObject.SetActive(false);
        sellButton.gameObject.SetActive(false);
        sellPriceText.gameObject.SetActive(false);
    }

    public void SetEngineDate(string updatingDate) => engineUpdateDateText.text = updatingDate;

    public void OpenGameRequest()
    {
        requestCity.officePresenter = officePresenter;
        requestCity.gameObject.SetActive(true);

        gameObject.SetActive(false);
    }

    public void SpawnEngineUpdatingProgerssbar(EngineUpdatingProgressbar engineUpdatingProgressbar)
    {
        engineUpdatingProgressbar.GetRequestTime(60 / officePresenter.Exp(), 0);
        engineUpdatingProgressbar.GetUpdatingData(officePresenter);

        Instantiate(engineUpdatingProgressbar, bag);
    }

    public void SellOffice()
    {
        if (officePresenter.activeProject == null)
        {
            acquisition.SellOffice();
            CloseWindow();
        }
        else
        {
            acceptPanel.ShowWindow("The project is under development", "Sell");
            acceptPanel.gameObject.SetActive(true);
        }
    }

    public void UnusbscribeRent()
    {
        if (officePresenter.activeProject == null)
        {
            acquisition.UnsubscribeToRent();
            CloseWindow();
        }
        else
        {
            acceptPanel.ShowWindow("The project is under development", "Rent");
            acceptPanel.gameObject.SetActive(true);
        }
    }

    public void BuyAfterRent()
    {
        acquisition.UnsubscribeToRent();
        acquisition.BuyOffice();

        buyButton.gameObject.SetActive(false);
        rentButton.gameObject.SetActive(false);

        sellButton.gameObject.SetActive(true);
        sellPriceText.gameObject.SetActive(true);

        weeklyPaymentText.gameObject.SetActive(false);
    }

    public void SetOffice(OfficePresenter _office, OfficeAcquisition officeAcquisition)
    {
        acquisition = officeAcquisition;
        officePresenter = _office;
    }

    public void SetIntFields(int employees, int salary, int weeklyPayment, int releasedGamesAmount, int sellPrice)
    {
        salaryText.TransformText(salary);
        weeklyPaymentText.TransformText(weeklyPayment);
        sellPriceText.TransformText(sellPrice);

        employyesText.text = employees.ToString();
        releasedGamesText.text = releasedGamesAmount.ToString();
    }

    void CheckGameRequest()
    {
        if (Engine.GetEnginePrice() > 0)
        {
            gameRequestButtonImage.sprite = unlockSprite;
            gameRequestButton.enabled = true;
        }

        else
        {
            gameRequestButtonImage.sprite = lockSprite;
            gameRequestButton.enabled = false;
        }
    }

    public void SetOfficeName(string _name) => officeNameText.text = _name;

    public void SetOfficePhoto(Sprite photo) => officePhoto.sprite = photo;

    public void CloseWindow() => animator.Play("CloseWindow");
}