using UnityEngine;
using UnityEngine.UI;

public class NotePadTextArea : MonoBehaviour
{
    [SerializeField] Text textArea, headerTextArea;

    public void GetText(NotePad notePad)
    {
        textArea.text = notePad.textValue;
        headerTextArea.text = notePad.fileName;
    }
}