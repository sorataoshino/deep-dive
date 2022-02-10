using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [Header("AudioSources")]
    [SerializeField] AudioSource _movementAudioSource;
    [SerializeField] AudioSource _collisionAudioSource;
    [SerializeField] AudioSource _heartbeatAudioSource;

    [Header("Wood")]
    [SerializeField] AudioClip _walkWoodLeft;
    [SerializeField] AudioClip _walkWoodRight;
    [SerializeField] AudioClip _crouchWoodLeft;
    [SerializeField] AudioClip _crouchWoodRight;


    [Header("Gravel")]
    [SerializeField] AudioClip _walkGravelLeft;
    [SerializeField] AudioClip _walkGravelRight;
    [SerializeField] AudioClip _crouchGravelLeft;
    [SerializeField] AudioClip _crouchGravelRight;

    [Header("Sand")]
    [SerializeField] AudioClip _walkSandLeft;
    [SerializeField] AudioClip _walkSandRight;
    [SerializeField] AudioClip _crouchSandLeft;
    [SerializeField] AudioClip _crouchSandRight;

    [Header("Grass")]
    [SerializeField] AudioClip _walkGrassLeft;
    [SerializeField] AudioClip _walkGrassRight;
    [SerializeField] AudioClip _crouchGrassLeft;
    [SerializeField] AudioClip _crouchGrassRight;

    [Header("Jump")]
    [SerializeField] AudioClip _jumpWood;
    [SerializeField] AudioClip _jumpGravel;
    [SerializeField] AudioClip _jumpSand;
    [SerializeField] AudioClip _jumpGrass;

    [Header("Collision")]
    [SerializeField] AudioClip[] _collision;

    [Header("Heartbeat")]
    [SerializeField] AudioClip _heartbeat;

    TerrainDetector terrainDetector;

    bool _canPlaySoundAgain = true;

    private void Awake()
    {
        terrainDetector = new TerrainDetector();        
    }

    public void WalkLeftStep()
    {
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        switch (terrainTextureIndex)
        {
            case 0: //Gravel
                _movementAudioSource.PlayOneShot(_walkGravelLeft);
                break;
            case 1: //Sand
                _movementAudioSource.PlayOneShot(_walkSandLeft);
                break;
            case 2:  //Grass
                _movementAudioSource.PlayOneShot(_walkGrassLeft);
                break;
            default:
                _movementAudioSource.PlayOneShot(_walkWoodLeft);
                break;
        }
    }

    public void WalkRightStep()
    {
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        switch (terrainTextureIndex)
        {
            case 0: //Gravel
                _movementAudioSource.PlayOneShot(_walkGravelRight);
                break;
            case 1: //Sand
                _movementAudioSource.PlayOneShot(_walkSandRight);
                break;
            case 2:  //Grass
                _movementAudioSource.PlayOneShot(_walkGrassRight);
                break;
            default:
                _movementAudioSource.PlayOneShot(_walkWoodRight);
                break;
        }
    }
    public void CrouchLeftStep()
    {
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        switch (terrainTextureIndex)
        {
            case 0: //Gravel
                _movementAudioSource.PlayOneShot(_crouchGravelLeft);
                break;
            case 1: //Sand
                _movementAudioSource.PlayOneShot(_crouchSandLeft);
                break;
            case 2:  //Grass
                _movementAudioSource.PlayOneShot(_crouchGrassLeft);
                break;
            default:
                _movementAudioSource.PlayOneShot(_crouchWoodLeft);
                break;
        }
    }

    public void CrouchRightStep()
    {
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        switch (terrainTextureIndex)
        {
            case 0: //Gravel
                _movementAudioSource.PlayOneShot(_crouchGravelRight);
                break;
            case 1: //Sand
                _movementAudioSource.PlayOneShot(_crouchSandRight);
                break;
            case 2:  //Grass
                _movementAudioSource.PlayOneShot(_crouchGrassRight);
                break;
            default:
                _movementAudioSource.PlayOneShot(_crouchWoodRight);
                break;
        }
    }

    public void Jump()
    {
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        switch (terrainTextureIndex)
        {
            case 0: //Gravel
                _movementAudioSource.PlayOneShot(_jumpGravel);
                break;
            case 1: //Sand
                _movementAudioSource.PlayOneShot(_jumpSand);
                break;
            case 2:  //Grass
                _movementAudioSource.PlayOneShot(_jumpGrass);
                break;
            default:
                _movementAudioSource.PlayOneShot(_jumpWood);
                break;
        }
    }

    public void Collision()
    {
        _collisionAudioSource.PlayOneShot(_collision[Random.Range(0, _collision.Length)]);
    }

    public void Heartbeat(bool playSound)
    {
        if (playSound)
        {
            _heartbeatAudioSource.Play();
        }
        else
        {
            _heartbeatAudioSource.Stop();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Stone"))
        {
            if (_canPlaySoundAgain == true)
            {
                Collision();
                _canPlaySoundAgain = false;
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        _canPlaySoundAgain = true;
    }
}
