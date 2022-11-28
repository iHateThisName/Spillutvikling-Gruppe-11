using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for controlling the camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// The camera controller constructor.
    /// The camera controller is following the singleton design pattern.
    /// </summary>
    public static CameraController cameraController { get; private set; }

    [Header("Camera Settings")] [Tooltip("The camera following speed")]
    public float camFollowSpeed = 2f;

    [Tooltip("The camera's offset axis")] public float offsetYAxis = 1f;
    [Tooltip("The target to follow")] public Transform target;

    [Tooltip("The cameras x-axis position." +
             "If this is toggled, then the tower will be centered in the camera" +
             "If centerPosition is not used, then the camera will follow the player in both x-axis and in y-axis.")]
    public bool centerPosition = true;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (cameraController != null && cameraController != this)
        {
            Destroy(this);
        }
        else
        {
            cameraController = this;
        }

        float yPosition = target.position.y + offsetYAxis;
        float xPosition = GetXPosition();
        Vector3 pos = new Vector3(xPosition, yPosition, -10f);
        transform.position = Vector3.Slerp(transform.position, pos, camFollowSpeed * Time.deltaTime);
    }

    private void Awake()
    {
        SetCenterCamera();
    }

    /// <summary>
    /// Gets the x-axis position to use for the camera, based on the value of centerPosition.
    /// </summary>
    /// <returns>0 if centerPosition is set to true, else the targets x-axis position will be returned.</returns>
    private float GetXPosition()
    {
        return centerPosition switch
        {
            true => 0,
            false => target.position.x
        };
    }

    public void SetCenterCamera()
    {
        int centerCameraState = PlayerPrefs.GetInt("centerCamera");
        
        if (centerCameraState == 1)
        {
            centerPosition = true;
        }
        else
        {
            centerPosition = false;
        }
    }
}