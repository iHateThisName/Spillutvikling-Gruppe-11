using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Class which handles player movement.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("The movement speed of the player")]
    public float MovementSpeed = 10f;

    [Tooltip("The jump force to be applied to the player jumps")]
    public float JumpForce = 20f;

    [Tooltip("The current movement.")]
    float movement = 0f;

    [Tooltip("Shall the player currently face right?")]
    bool isFacingRight = true;

    [Tooltip("The player animator to be used")]
    public Animator animator;

    [Tooltip("The rigidbody is used to move the player. This is neccesary and therefore not public.")]
    private Rigidbody2D rb;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Flips the player horizontal.
    /// </summary>
    void flipPlayer()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

        movement = Input.GetAxis("Horizontal");

        if (movement < 0 && isFacingRight)
        {
            flipPlayer();
        }
        else if (movement > 0 && !isFacingRight)
        {
            flipPlayer();
        }


        animator.SetFloat("Speed", Mathf.Abs(movement));
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
