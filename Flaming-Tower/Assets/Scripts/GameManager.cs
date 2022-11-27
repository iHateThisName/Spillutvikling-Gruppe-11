using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// This class acts like a game manager.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The gameManager constructor.
    /// The gameManger is following the singleton design pattern.
    /// </summary>
    public static GameManager gameManager
    {
        get; 
        private set;
    }

    [Header("Game Objects")]
    [Tooltip("The player game object")]
    [SerializeField] private GameObject player;

    [Header("Canvas Objects")]
    [Tooltip("The game over screen")]
    [SerializeField] private GameObject gameOverScreen;
    [Tooltip("The in game overlay")]
    [SerializeField] private GameObject inGameScreen;

    [Tooltip("The Text Mesh pro to update for the High-score")]
    [SerializeField] private TextMeshProUGUI highScoreText;
    [Tooltip("The Text Mesh pro to update for the score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [Tooltip("The Text Mesh pro to update the score text at gameover")]
    [SerializeField] private TextMeshProUGUI scoreTextGameOver;
    
    [Header("Scripts")] [SerializeReference]
    private MovingLava movingLava;

    [Tooltip("The current score.")]
    private int _score;
    [Tooltip("Holds the starting position value")]
    private int _lowestValue;

    private PlayerController _playerController;

    /// <summary>
    /// This method is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        _playerController = player.GetComponent<PlayerController>();
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

    /// <summary>
    /// This method is called for every frame, as long as MonoBehaviour is being used.
    /// </summary>
    private void Update()
    {
        CheckScore();
        CheckHighScore();
    }

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    private void Start()
    {
        UpdateHighScoreText();
        _lowestValue = (int)Math.Round(player.transform.position.y);
    }



    /// <summary>
    /// Shows the game over screen.
    /// </summary>
    public void ShowGameOverScreen()
    {
        movingLava.LavaRise(false);
        inGameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        _playerController.AllowMovement(false);
    }

    /// <summary>
    /// Loads the main menu.
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Restarts the game.
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene("Jump Tower");
    }

    /// <summary>
    /// Checks the highscore and updates it if the player passes the current highscore.
    /// </summary>
    private void CheckHighScore()
    {
        if (_score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            //Updating the High-score dynamic 
            UpdateHighScoreText();
        }
    }

    /// <summary>
    /// Updates the visible high score text.
    /// </summary>
    private void UpdateHighScoreText()
    {
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    /// <summary>
    /// Updates the visible score text.
    /// </summary>
    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {_score}";
        scoreTextGameOver.text = $"Score: {_score}";
    }

    /// <summary>
    /// A methode to retrieve the current score.
    /// </summary>
    public int GetScore()
    {
        return _score;
    }

    /// <summary>
    /// Checks the score of the current game.
    /// Also sets the current score.
    /// If the score haven't been increased then the lava wont move.
    /// </summary>
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
    }


}
