using UnityEngine;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour
{
    Sprite image;
    [SerializeField] Image languageSettingsIcon;

    [SerializeField] string languageCode = "#";

    private void Awake() => image = GetComponent<Image>().sprite;

    public void ChangeLanguage()
    {
        languageSettingsIcon.sprite = image;
        //
    }
}