using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class which handles player movement
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("The movement speed of the player")]
	public float MovementSpeed = 1;
    [Tooltip("The jump force to be applied to the player jumps")]
    public float JumpForce = 10;
    //The rigidbody is used to move the player. This is neccesary and therefore not public.
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
		var movement = Input.GetAxis("Horizontal");
		transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f) 
		{
			rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
		}
    }
}
