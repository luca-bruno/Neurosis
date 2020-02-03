using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
	private Rigidbody2D rb;
	private SpriteRenderer spr;
	private Animator anim;
	public float speed;
	public float jumpForce;
	private bool facingRight;  // For determining which way the player is currently facing.
	private bool isGrounded;
	public Transform groundCheck;
	public LayerMask whatisGround;

    void Start(){
		rb = GetComponent<Rigidbody2D>();
		spr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}

	void Update(){
		//moveInput = Input.GetAxis("Horizontal"); //takes x axis position value into float
	//	rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

		if(Physics2D.Linecast(transform.position, groundCheck.position, whatisGround)){
			isGrounded = true;
		}
		else {
			isGrounded = false;
		}

		if(Input.GetKey("left") || (Input.GetKey("a"))){ //if moves left
			rb.velocity = new Vector2(speed * -1, rb.velocity.y);
		
			if (isGrounded == true){
				anim.Play("Player_Run");
			}
		
			facingRight = false;
			spr.flipX = true;
		} else if (Input.GetKey("right") || (Input.GetKey("d"))){ //if moves right
			rb.velocity = new Vector2(speed, rb.velocity.y);
		
			if (isGrounded == true){
			anim.Play("Player_Run");
			}
		
			facingRight = true;
			spr.flipX = false;
		}
		else {
			if (isGrounded == true){
			anim.Play("Player_Idle");
			}
			
			rb.velocity = new Vector2(0, rb.velocity.y);
		}
		
		if ((Input.GetKey("space") || Input.GetKey("w")) && isGrounded == true){
			anim.Play("Player_Jump");
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
	}
}
