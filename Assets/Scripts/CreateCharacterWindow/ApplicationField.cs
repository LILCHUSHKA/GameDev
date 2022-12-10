using UnityEngine;
using UnityEngine.UI;

public class ApplicationField : MonoBehaviour
{
    [SerializeField] FieldsEmpty parent;

    [SerializeField] Text thisFieldText;

    bool isEmpty = true;

    public void CheckFieldText(Text fieldText)
    {
        if (thisFieldText.text.Length > 2) isEmpty = false;
        else isEmpty = true;

        if (fieldText.text.Length > 2 && !isEmpty)
            parent.ShowNextFields();
    }
}