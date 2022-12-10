using UnityEngine;
using System.Collections.Generic;

public class ExpensesList : MonoBehaviour
{
    [SerializeField] PaymentPresenter paymentPresenter;

    public static ExpensesList expensesList;

    [SerializeField] List<Expense> expenses = new List<Expense>();

    private void Awake() => expensesList = this;

    public void AddPayment(string description, Color backColor, int value)
    {
        if (value > 0)
        {
            Expense expense = new Expense();

            expense.description = description;
            expense.backColor = backColor;
            expense.value = value;

            expenses.Add(expense);

            paymentPresenter.GetPaymentData(expenses[expenses.Count - 1]);

            Instantiate(paymentPresenter, transform);
        }
    }
}