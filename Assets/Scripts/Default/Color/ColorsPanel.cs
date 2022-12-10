using UnityEngine;
using UnityEngine.UI;

public class ColorsPanel : MonoBehaviour
{
    [SerializeField] Image pastColorImage, newColorImage;

    [SerializeField] GameObject changedObject;

    private void OnEnable()
    {
        newColorImage.color = pastColorImage.color;
        Time.timeScale = 0;
    }

    private void OnDisable() => Time.timeScale = 1;

    public void GetObject(GameObject go)
    {
        changedObject = go;

        if (changedObject.GetComponent<Image>())
            pastColorImage.color = changedObject.GetComponent<Image>().color;

        if (changedObject.GetComponent<Text>())
            pastColorImage.color = changedObject.GetComponent<Text>().color;
    }

    public void ChangeColor(Color32 newColor)
    {
        if (changedObject.GetComponent<Image>())
        {
            changedObject.GetComponent<Image>().color = newColor;
            newColorImage.color = newColor;
        }

        if (changedObject.GetComponent<Text>())
        {
            changedObject.GetComponent<Text>().color = newColor;
            newColorImage.color = newColor;
        }
    }

    public void SetPastColor() => ChangeColor(pastColorImage.color);
}