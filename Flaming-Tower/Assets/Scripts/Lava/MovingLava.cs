using UnityEngine;

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
             "This will determined how often the lava speed increases. " +
             "Example if set to 5 then speed will increase when score is 5,10,15...")]
    public int scoreDivider = 10;

    private int _score;
    private bool _stopRising;

    private void UpdateScore()
    {
        _score = GameManager.gameManager.GetScore();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        // If the player have not jumped then dont move the lava
        if (_score == 0)
        {
            _stopRising = true;
        }
        
        // When the player have moved start moving the lava
        if (_score == 1)
        {
            _stopRising = false;
        }

        if (!_stopRising)
        {
            // Updating the position (Making the lava rise)
            transform.position += new Vector3(0, lavaSpeed / 1000, 0);
            SpeedUpLava();
            _score = GameManager.gameManager.GetScore();
        }
        
        Debug.Log($"The score is: {_score}, The lava speed is: {lavaSpeed}, The lava is set to rise {!_stopRising}");
        
        // Retrieve the current score
        UpdateScore();

    }

    private void SpeedUpLava()
    {
        _score = GameManager.gameManager.GetScore();
        if (_score % scoreDivider == 0)
        {
            lavaSpeed += lavaSpeedIncrease;
        }
        
    }

    /// <summary>
    /// A way to stop the rising lava
    /// </summary>
    /// <param name="lavaRise"></param>
    public void LavaRise(bool lavaRise)
    {
        _stopRising = !lavaRise;
    }
}
