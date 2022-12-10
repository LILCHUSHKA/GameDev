using UnityEngine;
using UnityEngine.UI;

public class FieldsEmpty : MonoBehaviour
{
    [SerializeField] GameObject nextEmpty;

    Image image;

    [SerializeField] Color disactiveColor;

    private void Awake() => image = GetComponent<Image>();

    public void ShowNextFields()
    {
        ChangeColor();
        nextEmpty.SetActive(true);
    }

    void ChangeColor() => image.color = disactiveColor;
}