using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public string loadSceneAfterIntro;
    
    void OnEnable()
    {
        // Only specifying the sceneName or sceneBuildIndex
        // will load the Scene with the Single mode
        SceneManager.LoadScene(loadSceneAfterIntro, LoadSceneMode.Single);
    }
}
