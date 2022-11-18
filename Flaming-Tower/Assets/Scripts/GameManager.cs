using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    
    [Header("Game Objects")]
    [Tooltip("The player game object")]
    public GameObject player;
    [Tooltip("The Lava game object")]
    public GameObject lava;
    
    [Header("Pages")]
    public GameObject gameOverScreen;

    public GameObject inGameScreen;

    void Awake()
    {
        
        inGameScreen.SetActive(true);
        
        // Creating a singleton
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }
    
    // A way to change the speed of the lava
    void lavaSpeed(float speed)
    {
        lava.GetComponent<MovingLava>().lavaSpeed = speed;
    }

    public void ShowGameOverScreen()
    {
        inGameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        player.SetActive(false);
        lavaSpeed(0);
    }
    
    
}
