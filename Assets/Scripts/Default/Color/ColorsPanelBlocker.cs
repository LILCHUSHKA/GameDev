using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ColorsPanelBlocker : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] UnityEvent OnClick = new UnityEvent();

    public ColorsPanel colorsPanel;

    public void OnPointerClick(PointerEventData eventData) =>
        OnClick.Invoke();
}