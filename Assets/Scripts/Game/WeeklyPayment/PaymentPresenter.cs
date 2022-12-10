using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PaymentPresenter : MonoBehaviour
{
    [SerializeField] TextTranformations paymentValueText;

    [SerializeField] Text paymentDescriptionText;

    [SerializeField] Image paymentBackground;

    [SerializeField] Animator animator;

    private void OnEnable() => StartCoroutine(DestroyTimer());

    public void GetPaymentData(Expense expenseData)
    {
        paymentDescriptionText.text = expenseData.description;
        paymentBackground.color = expenseData.backColor;

        paymentValueText.TransformText(expenseData.value);
    }

    public void DestroyPrefab() => Destroy(gameObject);

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSecondsRealtime(4f);
        animator.Play("Destroy");
    }
}