using UnityEngine;
using UnityEngine.UI;

public class LoanSlider : MonoBehaviour
{
    [SerializeField] TextTranformations loanText, loanSum;

    Slider slider;

    [SerializeField] float percent;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeLoanText()
    {
        loanText.TransformText(((int)slider.value));
        loanSum.TransformText(System.Convert.ToInt32(slider.value * percent));
    }
}