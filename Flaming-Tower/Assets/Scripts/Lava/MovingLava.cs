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

    }

    public void LavaRise(bool lavaRise)
    {
        _stopRising = !lavaRise;
    }
}
