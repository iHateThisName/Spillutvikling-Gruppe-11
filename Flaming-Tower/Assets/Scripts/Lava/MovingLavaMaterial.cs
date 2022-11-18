using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovingLavaMaterial : MonoBehaviour
{
    [FormerlySerializedAs("Speed of the Texture")] public float speed = 0.1f;
    private Renderer _rend;

    private static readonly int MainTex = Shader.PropertyToID("_MainTex");

    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Moving the material
        float moveThis = Time.time * speed;
        _rend.material.SetTextureOffset(MainTex, new Vector2
            (moveThis, moveThis / 2));

    }
}

