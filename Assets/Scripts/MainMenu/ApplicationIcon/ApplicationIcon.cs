using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;

public class ApplicationIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] UnityEvent OnDoubleClick;

    [SerializeField] WorkArea workArea;

    public Image icon;
    Image iconAlphaChanal;

    [SerializeField] float clickDelay = 0.5f;

    bool isReady = false;
    bool isOpen = false;

    private void Awake() => iconAlphaChanal = GetComponent<Image>();

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isOpen)
        {
            if (isReady)
            {
                RemoveIsReady();
                ChangeAlpha(0);

                AddIconOnDownPanel();

                OnDoubleClick.Invoke();
            }
            else
            {
                isReady = true;
                StartCoroutine(ClickRemoveTimer());
            }

            ChangeAlpha(0.3f);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) => ChangeAlpha(0.2f);

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isReady)
            ChangeAlpha(0);
    }

    IEnumerator ClickRemoveTimer()
    {
        yield return new WaitForSeconds(clickDelay);
        RemoveIsReady();
    }

    void ChangeAlpha(float alpha) => iconAlphaChanal.color = new Color(255, 255, 255, alpha);

    public void AddIconOnDownPanel() => workArea.SpawnIconInDownPanel(icon.sprite);

    public void RemoveIsReady() => isReady = false;

    //Костыль
    public void HandleIsOpen(bool state) => isOpen = state;
}