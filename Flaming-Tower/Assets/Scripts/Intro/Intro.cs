using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public string loadScene;
    


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