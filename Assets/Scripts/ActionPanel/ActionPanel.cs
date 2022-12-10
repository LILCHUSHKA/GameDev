using UnityEngine;

public class ActionPanel : MonoBehaviour
{
    [SerializeField] TextTranformations moneyText, fansText;

    [SerializeField] Animator mapAnimator;
    Animator animator;

    public static int money { get; private set; } = 13633000;
    public static int fans { get; private set; } = 0;

    public bool isHiden;

    private void Awake() => animator = GetComponent<Animator>();

    void UpdateTextData()
    {
        moneyText.TransformText(money);
        fansText.TransformText(fans);
    }

    public void ActivePanel()
    {
        if (CheckActiveSelf())
        {
            animator.SetTrigger("Hide");
            mapAnimator.SetTrigger("HideActionPanel");
        }
        else
        {
            animator.SetTrigger("Show");
            mapAnimator.SetTrigger("ShowActionPanel");

            UpdateTextData();
        }
    }

    public static void AddMoney(int value)
    {
        money += value;
        ExpensesList.expensesList.AddPayment("Profit :", new Color32(0, 155, 0, 130), value);
    }

    public static void TakeMoney(int value)
    {
        money -= value;
        ExpensesList.expensesList.AddPayment("Price :", new Color32(155, 0, 0, 130), value);
    }

    public static void AddFans(int value)
    {
        fans += value;
        ExpensesList.expensesList.AddPayment("New fans :", new Color32(0, 0, 155, 130), value);
    }

    public static void TakeFans(int value)
    {
        fans -= value;
        ExpensesList.expensesList.AddPayment("Fans gone :", new Color32(0, 155, 0, 130), value);
    }

    public static int GetMoneyAmount()
    {
        return money;
    }

    bool CheckActiveSelf()
    {
        return isHiden;
    }
}