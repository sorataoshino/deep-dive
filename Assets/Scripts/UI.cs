using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public void GameStart()
    {
        GameManager.Instance.SetState(GameState.START);
    }

    public void GameResume()
    {
        GameManager.Instance.SetState(GameState.PLAYING);
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
