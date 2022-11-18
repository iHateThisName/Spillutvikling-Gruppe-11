using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for controlling the camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    [Tooltip("The camera following speed")]
    public float camFollowSpeed = 2f;
    [Tooltip("The camera's offset axis")]
    public float offsetYAxis = 1f;
    [Tooltip("The target to follow")]
    public Transform target;

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = new Vector3(target.position.x, target.position.y + offsetYAxis, -10f);
        transform.position = Vector3.Slerp(transform.position, pos, camFollowSpeed * Time.deltaTime);
        
    }
}
