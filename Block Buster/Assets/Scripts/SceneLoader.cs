using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    string CREDITS_HANDLER = "Credits";

    public void LoadNextScene()
    {
        int current_scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current_scene + 1);
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
        GameStatus gameStatus = FindObjectOfType<GameStatus>();
        if (gameStatus)
        {
            gameStatus.ResetScore();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(CREDITS_HANDLER);
    }
}
