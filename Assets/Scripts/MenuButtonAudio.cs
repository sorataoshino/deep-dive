using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonAudio : MonoBehaviour
{
    [SerializeField] AudioClip[] _audioClips; //LINKS, OBEN, RECHTS, UNTEN
    [SerializeField] AudioSource _audioSource;

    PlayerInputAction _actions;
    Vector2 currentInput;

    private void Awake()
    {
        _actions = new PlayerInputAction();

        _actions.UI.ArrowKeys.performed += ctx => currentInput = ctx.ReadValue<Vector2>();
    }

    public void OnArrow()
    {

        if (currentInput.x > 0) //Right
        {
            _audioSource.PlayOneShot(_audioClips[0]);
        }

        if (currentInput.x < 0) //Left
        {
            _audioSource.PlayOneShot(_audioClips[1]);
        }

        if (currentInput.y > 0) //Up
        {
            _audioSource.PlayOneShot(_audioClips[2]);
        }

        if (currentInput.y < 0) //Down
        {
            _audioSource.PlayOneShot(_audioClips[3]);
        }
    }

    public void OnPointerEnter()
    {
        _audioSource.PlayOneShot(_audioClips[2]);
    }

    private void OnEnable()
    {
        _actions.UI.Enable();
    }

    private void OnDisable()
    {
        _actions.UI.Disable();
    }
}
