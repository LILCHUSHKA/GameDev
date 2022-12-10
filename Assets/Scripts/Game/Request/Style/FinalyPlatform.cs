using UnityEngine;
using UnityEngine.UI;

public class FinalyPlatform : MonoBehaviour
{
    public Platform platform;

    [SerializeField] Image platformButton;
    [SerializeField] Sprite defaultSprite;

    public void GetPlatform(Platform _platform) => platform = _platform;

    public void ClearPlatformField()
    {
        if (platform != null)
        {
            platform = null;
            platformButton.sprite = defaultSprite;
        }
    }
}