using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// This class is responsible for moving the lava.
/// </summary>
public class MovingLava : MonoBehaviour
{
    [Header("Component settings")]
    [Tooltip("The speed of the movement of the lava.")]
    public float lavaSpeed = 5f;
    
    [Tooltip("The amount the lava speed will increase by")]
    public float lavaSpeedIncrease = 0.2f;
    
    [Tooltip("The value the score can be divide by. " +
             "Example if set to 5 then speed will increase when score is 5,10,15...")]
    public int scoreDivider = 10;

    private int _score;
    private bool _stopRising;

    public MovingLava()
    {
        _score = GameManager.gameManager.GetScore();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (_score == 0)
        {
            _stopRising = true;
        }

        if (_stopRising) return;
        // Updating the position (Making the lava rise)
        transform.position += new Vector3(0, lavaSpeed / 1000, 0);
        SpeedUpLava();

    }

    private void SpeedUpLava()
    {
        _score = GameManager.gameManager.GetScore();
        if (_score % scoreDivider == 0)
        {
            lavaSpeed += lavaSpeedIncrease;
        }
        
    }

    public void LavaRise(bool lavaRise)
    {
        _stopRising = !lavaRise;
    }
}
