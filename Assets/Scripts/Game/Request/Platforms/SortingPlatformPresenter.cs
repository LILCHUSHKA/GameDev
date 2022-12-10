using UnityEngine;
using UnityEngine.UI;

public class SortingPlatformPresenter : MonoBehaviour
{
    [SerializeField] PastGameSorting pastGameSorting;

    [SerializeField] Platform platformData;

    [SerializeField] Text platformNameText;

    [SerializeField] Image platformImage;

    [SerializeField] Transform parent;

    public void GetPlatformData(Platform platform, PastGameSorting sorting)
    {
        platformData = platform;
        pastGameSorting = sorting;

        platformNameText.text = platform.platformName;
        platformImage.sprite = platform.platformIcon;
    }

    public void GetParent(Transform _parent) => parent = _parent;

    public void SetSortingPlatform()
    {
        pastGameSorting.SortingToPlatform(platformData);
        parent.gameObject.SetActive(false);
    }
}