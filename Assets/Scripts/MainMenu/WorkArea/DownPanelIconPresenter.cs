using UnityEngine;
using UnityEngine.UI;

public class DownPanelIconPresenter : MonoBehaviour
{
    [SerializeField] Image icon;

    public void GetIconSprite(Sprite sprite) => icon.sprite = sprite;
}