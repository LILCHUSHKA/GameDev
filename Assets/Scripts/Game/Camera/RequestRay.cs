using UnityEngine;

public class RequestRay : MonoBehaviour
{
    [SerializeField] GameObject requestsPanel;
    [SerializeField] RequestCity requestCity;

    Vector2 mousePos;
    RaycastHit2D rayHit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rayHit = Physics2D.Raycast(mousePos, -Vector2.up);

            if (rayHit.collider.GetComponent<OfficePresenter>()) SetRequestCity();
        }
    }

    public void GetRequestData(RequestCity requestCityData) => requestCity = requestCityData;

    void SetRequestCity()
    {
        if (rayHit.collider.GetComponent<OfficePresenter>().office.isPlayerOffice)
        {
            requestCity.GetCity(rayHit.collider.GetComponent<OfficePresenter>());

            requestsPanel.SetActive(true);
            requestCity.gameObject.SetActive(true);

            this.enabled = false;
        }
    }
}