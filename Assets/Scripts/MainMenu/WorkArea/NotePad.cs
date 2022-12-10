using UnityEngine;

public class NotePad : MonoBehaviour
{
    public string fileName;

    [TextArea(10,10)] public string textValue;
}