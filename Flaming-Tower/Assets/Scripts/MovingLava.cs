using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLava : MonoBehaviour
{
    public float lavaSpeed = 5f;

    // Update is called once per frame
    void Update()
    {

        // Updating the position (Making the lava rise)
        transform.position += new Vector3(0, lavaSpeed / 1000, 0);

    }
}
