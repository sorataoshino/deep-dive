using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] List<AudioSource> _audioSources = new List<AudioSource>();
    [SerializeField] Slider _audioVolumeSlider;
    [SerializeField] Slider _mouseSensivitySlider;

    private void Start()
    {
        SaveData data = SaveSystem.Load();

        if (data != null)
        {
            _audioVolumeSlider.value = data.AudioVolume;

            foreach (AudioSource audio in _audioSources)
            {
                audio.volume = _audioVolumeSlider.value;
            }

            _mouseSensivitySlider.value = data.MouseSensivity;
        }
    }

    public void ChangeAudioVolume()
    {
        foreach (AudioSource audio in _audioSources)
        {
            audio.volume = _audioVolumeSlider.value;
        }
    }

    public void SaveSettings()
    {
        SaveSystem.SaveSettings(_audioVolumeSlider.value, _mouseSensivitySlider.value);
    }
}