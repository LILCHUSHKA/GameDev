using UnityEngine;
using UnityEngine.UI;

public class RequestCity : MonoBehaviour
{
    public OfficePresenter officePresenter;

    [SerializeField] RequestRay requestRay;

    [SerializeField] Text officeButtonText;

    string defaultOfficeButtonText = "Select studio";

    private void OnEnable()
    {
        if (officePresenter != null) officeButtonText.text = officePresenter.office.officeName;
        else officeButtonText.text = defaultOfficeButtonText;
    }

    public void ShowCities()
    {
        gameObject.SetActive(false);

        requestRay.enabled = true;
        requestRay.GetRequestData(this);
    }

    public void GetCity(OfficePresenter _office) => officePresenter = _office;

    public void ClearCity() => officePresenter = null;

    public bool CityIsNull()
    {
        return officePresenter == null;
    }
}