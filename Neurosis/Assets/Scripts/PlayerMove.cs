using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
	private Rigidbody2D rb;
	private SpriteRenderer spr;
	private float moveInput;
	public float speed = 5f;
	public float jumpForce = 5f;
	private bool facingRight = true;  // For determining which way the player is currently facing.
		

    void Start(){
		rb = GetComponent<Rigidbody2D>();
		spr = GetComponent<SpriteRenderer>();
	}

	void Update(){
		moveInput = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

		if(moveInput < 0){
			facingRight = false;
			spr.flipX = true;
		} else if (moveInput > 0){
			facingRight = true;
			spr.flipX = false;
		}
	}


	// private void Flip()
	// {
	// 	// Switch the way the player is labelled as facing.
	// 	facingRight = !facingRight;

	// 	// Multiply the player's x scale by -1.
	// 	Vector3 Scaler = transform.localScale;
	// 	Scaler.x *= -1;
	// 	transform.localScale = Scaler;
	}
//}
