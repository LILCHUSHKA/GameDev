using UnityEngine;

public class WeeklyPayment : MonoBehaviour
{
    [SerializeField] static int paymentValue;

    private void Start()
    {
        GlobalEvents.OnDateChange.AddListener((day, week, month, year) =>
        {
            if (day == 1)
            {
                if (paymentValue != 0) ActionPanel.TakeMoney(paymentValue);
            }
        });
    }

    public static void AddPaymentValue(int value) => paymentValue += value;

    public static void DecreasePaymentValue(int value) => paymentValue -= value;
}