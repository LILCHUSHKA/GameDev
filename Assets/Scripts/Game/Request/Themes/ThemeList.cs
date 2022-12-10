using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeList : MonoBehaviour
{
    [SerializeField] ThemePresenter themePresenter;
    [SerializeField] FinalyTheme finalyTheme;

    [SerializeField] Image addThemeButton;

    [SerializeField] Transform bag;

    [SerializeField] float spawnDelay = 0.1f;

    public List<Theme> themes;

    private void OnEnable() => SpawnPlatforms();

    void ClearBag()
    {
        foreach (Transform child in bag) Destroy(child.gameObject);
    }

    public void SpawnPlatforms()
    {
        ClearBag();
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        for (int i = 0; i < themes.Count; i++)
        {
            themePresenter.GetThemeData(themes[i]);
            themePresenter.GetParent(this);

            Instantiate(themePresenter, bag);

            yield return new WaitForSecondsRealtime(spawnDelay);
        }
    }

    public void SetTheme(Sprite icon, Theme theme)
    {
        addThemeButton.sprite = icon;
        finalyTheme.GetTheme(theme);
    }
}
