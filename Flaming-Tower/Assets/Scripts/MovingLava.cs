using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for moving the lava.
/// </summary>
public class MovingLava : MonoBehaviour
{
    [Header("Component settings")]
    [Tooltip("The speed of the movement of the lava.")]
    public float lavaSpeed = 5f;

    // Update is called once per frame
    void Update()
    {

        // Updating the position (Making the lava rise)
        transform.position += new Vector3(0, lavaSpeed / 1000, 0);

    }
}
