using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] Slider _audioVolumeSlider;
    [SerializeField] Slider _mouseSensivitySlider;

    private void Start()
    {
        SaveData data = SaveSystem.Load();

        if (data != null)
        {
            _audioVolumeSlider.value = data.AudioVolume;

            AudioListener.volume = _audioVolumeSlider.value;

            _mouseSensivitySlider.value = data.MouseSensivity;
        }
    }

    public void ChangeAudioVolume()
    {
        AudioListener.volume = _audioVolumeSlider.value;
    }

    public void SaveSettings()
    {
        SaveSystem.SaveSettings(_audioVolumeSlider.value, _mouseSensivitySlider.value);
    }
}