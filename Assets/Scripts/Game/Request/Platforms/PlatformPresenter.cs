using UnityEngine;
using UnityEngine.UI;

public class PlatformPresenter : MonoBehaviour
{
    [SerializeField] Text platformNameText;

    [SerializeField] Image platformIcon;

    [SerializeField] Platform platformData;
    [SerializeField] PlatformsList parent;
    [SerializeField] TextTranformations platformPriceText;

    [SerializeField] int platformPrice;

    enum Platforms
    {
        PC,
        PS,
        PSP,
        Switch,
        Mobile
    }
    Platforms gamePlatform;

    public void GetPlatformData(Platform platform)
    {
        platformData = platform;

        gamePlatform = (Platforms)platform.gamePlatform;

        platformNameText.text = platform.platformName;
        platformIcon.sprite = platform.platformIcon;
        platformPrice = platform.platformPrice;

        platformPriceText.TransformText(platformPrice);
    }

    public void HandleClick()
    {
        parent.SetPlatform(platformPrice, platformIcon.sprite, platformData);
        parent.gameObject.SetActive(false);
    }

    public void GetAdditionalData(PlatformsList _parent) => parent = _parent;
}