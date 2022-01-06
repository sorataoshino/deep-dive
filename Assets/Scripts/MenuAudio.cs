using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    [SerializeField] AudioClip _introAudio;
    [SerializeField] AudioClip _backgroundMusic;

    AudioSource _audio;

    [SerializeField] float _overlapSeconds = 1f;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        StartCoroutine(playSound());
    }

    IEnumerator playSound()
    {
        _audio.clip = _introAudio;
        _audio.Play();

        yield return new WaitForSeconds(_introAudio.length - _overlapSeconds);

        _audio.clip = _backgroundMusic;
        _audio.loop = true;
        _audio.Play();
    }
}
