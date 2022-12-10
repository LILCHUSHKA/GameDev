using UnityEngine;
using UnityEngine.UI;

public class StockOfficePresenter : MonoBehaviour
{
    [SerializeField] Text officeNameText, employeesAmountText;
    [SerializeField] GameObject line;

    public void GetOfficeData(string officeName, int employeesAmount)
    {
        officeNameText.text = officeName;
        employeesAmountText.text = employeesAmount.ToString();
    }

    public void ShowLine(bool state) => line.gameObject.SetActive(state);
}