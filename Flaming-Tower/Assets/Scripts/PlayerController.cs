using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

	public float MovementSpeed = 10f;
	public float JumpForce = 20f;  
  float movement = 0f;
  
  bool isFacingRight = true;

  public Animator animator;
	private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();   
    }

    void flipPlayer() {
      isFacingRight = !isFacingRight;
      transform.Rotate(0f, 180f, 0f);
    }

    // Update is called once per frame
    void Update() 
    {

		movement = Input.GetAxis("Horizontal");

    if (movement < 0 && isFacingRight) {
      flipPlayer();
    }
    else if (movement > 0 && !isFacingRight)
    {
      flipPlayer();
    }


    animator.SetFloat("Speed", Mathf.Abs(movement));
		transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f) 
		{
			rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
		}
    }
}
