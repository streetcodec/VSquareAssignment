using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public PlayFabManager playfab;

    public void Play()
    {
        SceneManager.LoadScene("Main");
    }
    public void LeaderBoard()
    {
        SceneManager.LoadScene("LeaderBoard");
        playfab.GetLeaderboard();

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void submit()
    {
        playfab.UpdateLeaderboard(PersistentManager.Instance.score);
        SceneManager.LoadScene("LeaderBoard");
         playfab.GetLeaderboard();
        Debug.Log(PersistentManager.Instance.score);
    }
}
