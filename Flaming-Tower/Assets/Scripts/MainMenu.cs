using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This class handles the main menu actions.
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField] public Toggle fullScreenToggle;
    [SerializeField] public Slider audioSlider;
    
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

    private void Awake()
    {
        ReadCenterCamera();
        ReadMusicVolume();
    }

    private void ReadMusicVolume()
    {
        if(!PlayerPrefs.HasKey("musicVolume")) {
            SetDefaultMusicVolume();
        }
        
        float storedVolume = PlayerPrefs.GetFloat("musicVolume");
        AudioListener.volume = storedVolume;
        audioSlider.value = storedVolume;
    }

    public void SaveMusicVolume() {
        AudioListener.volume = audioSlider.value;
        PlayerPrefs.SetFloat("musicVolume", audioSlider.value);
    }

    private void SetDefaultMusicVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", 1);
    }
    

    private void ReadCenterCamera()
    {
        fullScreenToggle.isOn = PlayerPrefs.GetInt("centerCamera") == 1;
    }

    public void SetCenterCamera()
    {
        PlayerPrefs.SetInt("centerCamera", fullScreenToggle.isOn ? 1 : 0);
    }


    /// <summary>
    /// This method is responsible to quit the game.
    /// </summary>
    public void QuitGame()
    {
// Checks if the game is being run as a standalone application and not inside the editor.
#if UNITY_STANDALONE
        // Application.Quit() only works in the standalone version of the unity game.
        //This do not work in the editor, but it should work in either the Windows/MacOS/WebGL version.
        Application.Quit();
#endif
        
// Checks if the game is being run in the editor and not in the the standalone version.
#if UNITY_EDITOR
        // Since Application.Quit() does not work in the editor,
        // due that that would stopped the whole editor,
        // UnityEditor.EditorApplication.isPlaying needs to be set to false when quitting the game.
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}