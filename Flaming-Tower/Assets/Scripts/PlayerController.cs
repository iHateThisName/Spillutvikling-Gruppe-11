using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

/// <summary>
/// Class which handles player movement.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("The movement speed of the player")]
    public float movementSpeed = 10f;

    [Tooltip("The jump force to be applied to the player jumps")]
    public float jumpForce = 20f;

    [Tooltip("The current movement.")]
    private float _movement = 0f;

    [Tooltip("Shall the player currently face right?")]
    private bool _isFacingRight = true;

    [Tooltip("The player animator to be used")]
    public Animator animator;

    [Tooltip("The rigidbody is used to move the player. This is necessary and therefore not public.")]
    private Rigidbody2D _rb;

    [SerializeField] private AudioSource jumpSoundEffect;

    private bool _allowMovement;

    private void Awake()
    {
        _allowMovement = true;
    }

    public void AllowMovement(bool allowMovement)
    {
        _allowMovement = allowMovement;
    }

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Flips the player horizontal.
    /// </summary>
    void flipPlayer()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

        if (_allowMovement)
        {
            _movement = Input.GetAxis("Horizontal");

            if (_movement < 0 && _isFacingRight)
            {
                flipPlayer();
            }
            else if (_movement > 0 && !_isFacingRight)
            {
                flipPlayer();
            }

            animator.SetFloat("Speed", Mathf.Abs(_movement));
            transform.position += new Vector3(_movement, 0, 0) * (Time.deltaTime * movementSpeed);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            jumpSoundEffect.Play();
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
