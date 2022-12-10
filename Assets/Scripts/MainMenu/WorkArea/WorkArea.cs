using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WorkArea : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] DownPanelIconPresenter iconPresenter;

    [SerializeField] Image backImage;

    [SerializeField] Transform downPanelBag;

    [SerializeField] List<Sprite> backgroundSprites;

    [SerializeField] List<ApplicationIcon> icons;

    private void OnEnable() => backImage.sprite = backgroundSprites[Random.Range(0, backgroundSprites.Count - 1)];

    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (ApplicationIcon icon in icons)
        {
            icon.RemoveIsReady();
        }
    }

    public void SpawnIconInDownPanel(Sprite sprite)
    {
        iconPresenter.GetIconSprite(sprite);
        Instantiate(iconPresenter, downPanelBag);
    }

    //Лютый костыль, когда сделаешь остальную игру - доделай рабочий стол
    public void RemoveIconInDownPanel(Transform bag)
    {
        Destroy(bag.GetChild(0).gameObject);
    }
}