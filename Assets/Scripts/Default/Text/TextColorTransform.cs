using UnityEngine;
using UnityEngine.UI;

public class TextColorTransform : MonoBehaviour
{
    [SerializeField] Image parentImage;

    Text text;

    private void Awake() => text = GetComponent<Text>();

    private void OnEnable() => CheckParentImageColor();

    void CheckParentImageColor()
    {
        if (parentImage.color.r == text.color.r) text.color = Color.black;
        else text.color = Color.white;
    }
}