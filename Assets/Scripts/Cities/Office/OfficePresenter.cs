using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class OfficePresenter : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] IndependentOffice independentOffice;

    [SerializeField] OfficeWindow infoWindow;

    [SerializeField] StudioInfoWindow studioInfoWindow;

    [SerializeField] OfficeAcquisition acquisition;

    [SerializeField] Image officeImage;

    [SerializeField] Text officeNameText, employeesAmountText;

    [SerializeField] Animator animator;

    [SerializeField] string engineUpdateDate;

    public Office office;

    public RequestProgressbar activeProject { get; private set; }

    public List<Technology> usedTechnologies { get; private set; }

    bool isBusy;

    private void Start() => office.OnActiveIndependent.AddListener(ActiveIndependent);

    private void OnEnable()
    {
        if (isBusy) ChangeColor(Color.magenta);

        if (office.isPlayerOffice && !isBusy) ChangeColor(Color.blue);

        if (!office.isPlayerOffice) ChangeColor(Color.green);

        if (!IsAvailability() && !office.isPlayerOffice) ChangeColor(Color.red);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (office.isPlayerOffice) ShowInfoWindow();

        else
        {
            studioInfoWindow.GetInfoAboutStudio(this, acquisition);
            Instantiate(studioInfoWindow, GameObject.FindObjectOfType<Canvas>().transform);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetTrigger("Selected");

        if (office.isPlayerOffice)
            ShowAdditionalInfo(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetTrigger("Deselected");
        ShowAdditionalInfo(false);
    }

    void ShowInfoWindow()
    {
        infoWindow.gameObject.SetActive(false);

        infoWindow.SetOffice(this, acquisition);
        infoWindow.SetOfficeName(office.officeName);
        infoWindow.SetOfficePhoto(office.officePhoto);
        infoWindow.SetIntFields(office.employeesAmount, Salary(), office.weeklyPaymentValue, office.releasedGamesAmount,
            (int)(office.price / 1.5f));

        infoWindow.gameObject.SetActive(true);
    }

    void ShowAdditionalInfo(bool active)
    {
        officeNameText.text = office.officeName;
        employeesAmountText.text = office.employeesAmount.ToString();

        officeNameText.gameObject.SetActive(active);
        employeesAmountText.gameObject.SetActive(active);
    }

    public void SetUsedEngine(List<Technology> newTechnologies)
    {
        usedTechnologies = newTechnologies;

        engineUpdateDate = GameTime.GetDate();

        infoWindow.SetEngineDate(engineUpdateDate);
    }

    public void UpdateOfficeState(bool busy, RequestProgressbar newProject)
    {
        isBusy = busy;
        activeProject = newProject;
    }

    public void ChangeColor(Color newColor) => officeImage.color = newColor;

    public void AddReleasedGame() => office.releasedGamesAmount++;

    public void AddSellPrice(int value) => office.price = +value;

    void ActiveIndependent() => independentOffice.enabled = true;

    public void ClearProjectField()
    {
        if (activeProject != null)
            activeProject.StartDestroing();
    }

    public int Exp()
    {
        int percent = 0;
        if (percent < 50) percent = office.releasedGamesAmount + 5;

        return percent;
    }

    public int Salary()
    {
        return office.salary * office.employeesAmount;
    }

    public bool IsAvailability()
    {
        return ActionPanel.GetMoneyAmount() > office.price;
    }
}