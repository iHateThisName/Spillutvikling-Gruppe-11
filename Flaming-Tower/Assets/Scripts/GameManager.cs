using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    
    [Header("Game Objects")]
    [Tooltip("The player game object")]
    [SerializeField] private GameObject player;
    [Tooltip("The Lava game object")]
    [SerializeField] private GameObject lava;
    
    [Header("Canvas Objects")]
    [Tooltip("The game over screen")]
    [SerializeField] private GameObject gameOverScreen;
    [Tooltip("The in game overlay")]
    [SerializeField] private GameObject inGameScreen;

    [Tooltip("The Text Mesh pro to update for the High-score")]
    [SerializeField] private TextMeshProUGUI highScoreText;
    [Tooltip("The Text Mesh pro to update for the score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreTextGameOver;

    private int _score;
    private int _lowestValue;

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

    private void Update()
    {
        CheckScore();
        CheckHighScore();
        
        
    }

    private void Start()
    {
        UpdateHighScoreText();
        _lowestValue = (int)Math.Round(player.transform.position.y);
    }

    // A way to change the speed of the lava
    void LavaSpeed(float speed)
    {
        lava.GetComponent<MovingLava>().lavaSpeed = speed;
    }

    public void ShowGameOverScreen()
    {
        inGameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        player.SetActive(false);
        LavaSpeed(0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Jump Tower");
    }

    private void CheckHighScore()
    {
        if (_score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            //Updating the High-score dynamic 
            UpdateHighScoreText();
        }
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {_score}";
        scoreTextGameOver.text = $"Score: {_score}";
        
    }

    private void CheckScore()
    {
        int playerYValueAsInt = (int)Math.Round(player.transform.position.y);

        if (playerYValueAsInt < _lowestValue)
        {
            _lowestValue = playerYValueAsInt;
        }

        if (_score < playerYValueAsInt)
        {
            _score = playerYValueAsInt;
            CheckHighScore();
            UpdateScoreText();
        }

        //If the player have not jumped then dont move the lava
        if (_score == 0)
        {
            LavaSpeed(0f);
        }
        
        //When the player have moved start moving the lava
        if (_score == 1)
        {
            LavaSpeed(8f);
        }
    }


}
