using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Level_0");
    }

    public void GameResume()
    {
        GameManager.Instance.SetState(GameState.PLAYING);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    /// <summary>
    /// If panel is active hide it, else show it
    /// </summary>
    /// <param name="ui"></param>
    public void SetActivePanel(GameObject ui)
    {
        ui.SetActive(!ui.activeSelf);
    }
}
