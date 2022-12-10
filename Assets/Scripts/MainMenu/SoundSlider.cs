using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] Volume volume;

    Slider slider;

    private void OnEnable() => slider = GetComponent<Slider>();

    public void ChangeSoundVolume(AudioMixerGroup selectMixerGroup)
    {
        selectMixerGroup.audioMixer.SetFloat(selectMixerGroup.name, slider.value - 80);

        volume.GetVolume(slider.value / 80);
    }
}