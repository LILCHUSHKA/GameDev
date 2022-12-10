using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonExtension : MonoBehaviour, IPointerEnterHandler
{
    AudioSource audioSource;
    [SerializeField] AudioClip hightlightedAudioClip;

    private void Awake() => audioSource = GetComponent<AudioSource>();

    public void OnPointerEnter(PointerEventData eventData) => audioSource.PlayOneShot(hightlightedAudioClip);
}