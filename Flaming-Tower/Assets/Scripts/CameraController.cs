using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public float camFollowSpeed = 2f;
    public float offsetYAxis = 1f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = new Vector3(target.position.x, target.position.y + offsetYAxis, -10f);
        transform.position = Vector3.Slerp(transform.position, pos, camFollowSpeed * Time.deltaTime);
        
    }
}
