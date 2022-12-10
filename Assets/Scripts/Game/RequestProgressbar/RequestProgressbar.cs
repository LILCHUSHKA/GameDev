using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RequestProgressbar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected OfficePresenter busyOffice;

    [SerializeField] Text stadyNameText, requestNameText;

    [SerializeField] protected Button cancelButton;

    [SerializeField] protected Slider progressbar;

    [SerializeField] protected int stadyStepValue;

    [SerializeField] protected List<string> stadyNames;

    [SerializeField] string requestName;

    private void Start()
    {
        SetStadyNames();
        GlobalEvents.OnDateChange.AddListener((day, week, month, year) => UpdateProgressbar());

        stadyStepValue += (int)Mathf.Sqrt(progressbar.maxValue);
    }

    public virtual void GetRequest(List<Technology> newTechnologies, OfficePresenter office)
    {
        busyOffice = office;
        busyOffice.UpdateOfficeState(true, this);

        WeeklyPayment.AddPaymentValue(busyOffice.Salary());
    }

    public virtual void GetRequest(NewGameData newGameData, OfficePresenter office)
    {
        busyOffice = office;
        busyOffice.UpdateOfficeState(true, this);

        WeeklyPayment.AddPaymentValue(busyOffice.Salary());
    }

    protected void SetRequestName(string _requestName)
    {
        requestName = _requestName;
        requestNameText.text = requestName;
    }

    public void GetRequestTime(int time, int percent) => progressbar.maxValue = time - ((time / 100) * percent);

    protected virtual void ProgressbarFinished()
    {
        GlobalEvents.OnDateChange.RemoveListener((day, week, month, year) => UpdateProgressbar());

        busyOffice.UpdateOfficeState(false, null);
        WeeklyPayment.DecreasePaymentValue(busyOffice.Salary());

        Destroy(gameObject);
    }

    void UpdateProgressbar()
    {
        progressbar.value++;

        if (progressbar.value == progressbar.maxValue) ProgressbarFinished();

        if (stadyNames.Count != 0)
        {
            stadyNameText.text = stadyNames[0];

            if (progressbar.value >= stadyStepValue)
            {
                stadyNames.RemoveAt(0);
                stadyStepValue += (int)Mathf.Sqrt(progressbar.maxValue);
            }
        }
    }

    public void StartDestroing()
    {
        busyOffice.UpdateOfficeState(false, null);
        Destroy(gameObject);
    }

    protected virtual void SetStadyNames() { }

    protected virtual void ShowAdditionalAction(bool state) => cancelButton.gameObject.SetActive(state);

    public void OnPointerEnter(PointerEventData eventData) => ShowAdditionalAction(true);

    public void OnPointerExit(PointerEventData eventData) => ShowAdditionalAction(false);
}