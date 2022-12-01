using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This class is responsible for loading the game scene.
/// </summary>
public class Intro : MonoBehaviour
{
    [Header("Scene settings")]
    [Tooltip("The scene to be loaded")]
    public string loadScene;
    

    /// <summary>
    /// Runs when the script is enabled.
    /// </summary>
    private void OnEnable()
    {
        if (String.IsNullOrEmpty(loadScene))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(loadScene);
        }
    }
    
    /// <summary>
    /// This method is responsible to load a scene.
    /// </summary>
    /// <param name="loadScene"></param>
    public void LoadScene(string loadScene)
    {
        if (String.IsNullOrEmpty(loadScene))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(loadScene);
        }
    }
}