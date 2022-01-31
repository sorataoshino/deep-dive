using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioAtRandomTime : MonoBehaviour
{

    [SerializeField] int minSeconds;
    [SerializeField] int maxSeconds;

    AudioSource _audioSource;
  
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        StartCoroutine(PlayAudio());
    }

    IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(Random.Range(minSeconds, maxSeconds));
        _audioSource.Play();
        StartCoroutine(PlayAudio());
    }
}
