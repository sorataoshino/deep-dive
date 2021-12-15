using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] GameObject _uiStart;
    [SerializeField] GameObject _uiPause;
    [SerializeField] GameObject _uiEnd;

    [Header("Cinemachine")]
    [SerializeField] CinemachineInputProvider _cinemachineInputProvider;
    InputActionReference _xyAxis;
    [SerializeField] Animator _animator;

    [SerializeField] Transform _player;
    [SerializeField] List<Transform> _enemies = new List<Transform>();

    Transform[] _enemyStartPosition;
    Transform _playerStartPosition;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one LevelManager in scene.");
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        GameManager.Instance.SetState(GameState.INTRO);

        _xyAxis = _cinemachineInputProvider.XYAxis;

        _enemyStartPosition = _enemies.ToArray();
        _playerStartPosition = _player.transform;

    }

    /// <summary>
    /// State when game is first opened.
    /// </summary>
    public void StateIntro()
    {
        _uiStart.SetActive(true);
        _animator.Play("IntroCamera");
    }

    /// <summary>
    /// Initialize a new round.
    /// </summary>
    public void StateStart()
    {
        _uiStart.SetActive(false);
        _animator.Play("PlayerCamera");

        GameManager.Instance.SetState(GameState.PLAYING);
    }

    /// <summary>
    /// state when the new round is running.
    /// </summary>
    public void StatePlaying()
    {
        _uiPause.SetActive(false);

        _cinemachineInputProvider.XYAxis = _xyAxis;

        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// state when the game is paused.
    /// </summary>
    public void StatePause()
    {
        _uiPause.SetActive(true);

        _cinemachineInputProvider.XYAxis = null;

        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// state when the player finished the round.
    /// </summary>
    public void StateEnd()
    {
        _uiEnd.SetActive(true);

        _cinemachineInputProvider.XYAxis = null;

        Cursor.lockState = CursorLockMode.None;

        if (GameManager.Instance.Won)
        {
            //TMP Highscore: {GameManager.Instance.Highscore} + seconds;
        }
        else
        {
            //TMP You Died
        }
    }
}
