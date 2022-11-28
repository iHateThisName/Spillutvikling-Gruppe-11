using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class handles the main menu actions.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// This method is responsible to load a scene.
    /// </summary>
    /// <param name="loadPlaySceneName"></param>
    public void PlayGame(string loadPlaySceneName)
    {
        if (loadPlaySceneName == "")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(loadPlaySceneName);
        }
    }

    /// <summary>
    /// This method is responsible to quit the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}