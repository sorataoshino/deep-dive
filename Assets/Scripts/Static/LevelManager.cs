using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public List<Transform> Chests = new List<Transform>();
    public bool Won;

    [SerializeField] GameObject _uiStart;
    [SerializeField] GameObject _uiPause;
    [SerializeField] GameObject _uiEnd;

    [SerializeField] TextMeshProUGUI _endText;

    [SerializeField] GameObject _compass;

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

    #region GameStates

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
        _uiEnd.SetActive(false);

        _animator.Play("PlayerCamera");

        _compass.GetComponent<Compass>().Initialize();

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
        _cinemachineInputProvider.XYAxis = null;

        Cursor.lockState = CursorLockMode.None;

        if (Won)
        {
            _endText.text = "Won";
            //TMP Highscore: {GameManager.Instance.Highscore} + seconds;
        }
        else
        {
            _endText.text = "You Died";
            //TMP You Died
        }

        _uiEnd.SetActive(true);
    }

    #endregion
}
