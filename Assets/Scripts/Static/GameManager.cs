using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public enum GameState {PLAYING, PAUSE}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState GameState { get; private set; }

    [SerializeField] CinemachineInputProvider _cinemachineInputProvider;
    InputActionReference _xyAxis;

    [SerializeField] GameObject _uiSettings;
    [SerializeField] GameObject _compass;

    [SerializeField] List<GameObject> _chests = new List<GameObject>();

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one GameManager in scene.");
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _xyAxis = _cinemachineInputProvider.XYAxis;

        _compass.GetComponent<Compass>().Initialize();

        SetState(GameState.PLAYING);
    }

    public void ChestOpened(GameObject chest)
    {
        _chests.Remove(chest);

        if (_chests.Count == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("EndScreen");
        }
    }

    public void SetState(GameState state)
    {
        GameState = state;

        switch (state)
        {
            case GameState.PLAYING:

                _uiSettings.SetActive(false);
                _cinemachineInputProvider.XYAxis = _xyAxis;
                Cursor.lockState = CursorLockMode.Locked;

                break;
            case GameState.PAUSE:

                _uiSettings.SetActive(true);

                _cinemachineInputProvider.XYAxis = null;
                Cursor.lockState = CursorLockMode.None;

                break;
            default:
                break;
        }
    }
}