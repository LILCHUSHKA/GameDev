using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] Image volumeImage;

    [SerializeField] Sprite volume_0, volume_1, volume_2, volume_off;

    public void GetVolume(float volumeValue)
    {
        if (volumeValue == 1) volumeImage.sprite = volume_0;
        if (volumeValue < 1 && volumeValue > 0.4f) volumeImage.sprite = volume_1;
        if (volumeValue < 0.4f && volumeValue > 0) volumeImage.sprite = volume_2;
        if (volumeValue == 0) volumeImage.sprite = volume_off;
    }
}