using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// This class is responsible for moving the lava material.
/// </summary>
public class MovingLavaMaterial : MonoBehaviour
{
    [Header("Movement Settings")]
    [FormerlySerializedAs("Speed of the Texture")]
    [Tooltip("The speed of the lava material")]
    public float speed = 0.1f;
    [Tooltip("The renderer")]
    private Renderer _rend;

    [Tooltip("The MainTexture")]
    private static readonly int MainTex = Shader.PropertyToID("_MainTex");

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        _rend = GetComponent<Renderer>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        /// Moving the material
        float moveThis = Time.time * speed;
        _rend.material.SetTextureOffset(MainTex, new Vector2
            (moveThis, moveThis / 2));

    }
}

