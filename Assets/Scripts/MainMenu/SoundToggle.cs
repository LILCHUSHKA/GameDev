using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundToggle : MonoBehaviour
{
    Toggle toggle;

    private void OnEnable() => toggle = GetComponent<Toggle>();

    public void ChangeToggleValue(AudioMixerGroup selectMixerGroup)
    {
        if (toggle.isOn) selectMixerGroup.audioMixer.SetFloat(selectMixerGroup.name, 0);
        else selectMixerGroup.audioMixer.SetFloat(selectMixerGroup.name, -80);
    }
}