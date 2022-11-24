using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

/// <summary>
/// This class handles the pausemenu.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    // Holds the boolean status for if the either the game is paused or not.
    [Header("Pause Menu Settings")]
    [Tooltip("Sets if the game is paused by default")]
    public static bool GameIsPaused = false;
    [Tooltip("The pause menu UI")]
    public GameObject pauseMenuUI;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
        
    }

    /// <summary>
    /// Resumes the game.
    /// </summary>
    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    /// <summary>
    /// Pauses the game.
    /// </summary>
    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    /// <summary>
    /// Changes to the main menu scene.
    /// </summary>
    public void GoToMainMenu() {
        GameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
        
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame() {
        Debug.Log("Quitting");
        Application.Quit();
    }
    
}
