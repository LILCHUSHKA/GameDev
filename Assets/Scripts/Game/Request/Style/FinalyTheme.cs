using UnityEngine;
using UnityEngine.UI;

public class FinalyTheme : MonoBehaviour
{
    public Theme theme;

    [SerializeField] Image themeButton;
    [SerializeField] Sprite defaultSprite;

    public void GetTheme(Theme _theme) => theme = _theme;

    public void ClearThemeField()
    {
        if (theme != null)
        {
            theme = null;
            themeButton.sprite = defaultSprite;
        }
    }
}