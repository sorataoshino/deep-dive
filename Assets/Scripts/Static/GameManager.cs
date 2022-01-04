using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { INTRO, START, PLAYING, PAUSE, END}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState { get; private set; }

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

    public void SetState(GameState state)
    {
        GameState = state;

        switch (state)
        {
            case GameState.INTRO:
                LevelManager.Instance.StateIntro();
                break;
            case GameState.START:
                LevelManager.Instance.StateStart();
                break;
            case GameState.PLAYING:
                LevelManager.Instance.StatePlaying();
                break;
            case GameState.PAUSE:
                LevelManager.Instance.StatePause();
                break;
            case GameState.END:
                LevelManager.Instance.StateEnd();
                break;
            default:
                break;
        }
    }
}