using UnityEngine;
using UnityEngine.UI;

public class ThemePresenter : MonoBehaviour
{
    [SerializeField] Text themeName;
    [SerializeField] Image themeIcon;

    [SerializeField] ThemeList themeParentList;

    [SerializeField] Theme themeData;

    enum GameThemes
    {
        city,
        fighting,
        racing
    }
    [SerializeField] GameThemes gameTheme;

    public void GetThemeData(Theme _theme)
    {
        themeData = _theme;

        gameTheme = (GameThemes)_theme.gameTheme;

        themeName.text = _theme.themeName;
        themeIcon.sprite = _theme.icon;
    }

    public void HandleClick()
    {
        themeParentList.SetTheme(themeIcon.sprite, themeData);
        themeParentList.gameObject.SetActive(false);
    }

    public void GetParent(ThemeList _parent) => themeParentList = _parent;
}