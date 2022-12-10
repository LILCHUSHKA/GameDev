using UnityEngine;
using UnityEngine.UI;

public class FavoriteButton : MonoBehaviour
{
    [SerializeField] Sprite activeSprite, defaultSprite;

    [SerializeField] Image image;

    public void ChangeSprite(bool state)
    {
        if (state == false) image.sprite = defaultSprite;
        else image.sprite = activeSprite;
    }
}