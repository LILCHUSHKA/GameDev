using UnityEngine;
using System.Collections.Generic;

public class OfficesPanel : MonoBehaviour
{
    [SerializeField] StockOfficePresenter officePresenter;

    [SerializeField] RectTransform rect;

    public void RenderOffices(List<Office> offices)
    {
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, 50f);

        foreach (Transform child in transform) Destroy(child.gameObject);

        rect.sizeDelta = new Vector2(rect.sizeDelta.x,
            rect.sizeDelta.y * (offices.Count));
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y - (23 * offices.Count - 1));

        for (int i = 0; i < offices.Count; i++)
        {
            officePresenter.GetOfficeData(offices[i].officeName, offices[i].employeesAmount);

            if (i != offices.Count - 1)
                officePresenter.ShowLine(true);

            else officePresenter.ShowLine(false);

            Instantiate(officePresenter, transform);
        }
    }
}