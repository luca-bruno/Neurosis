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
	private bool isAttacking = false;
	public Transform groundCheck;
	public LayerMask whatisGround;

    void Start(){
		rb = GetComponent<Rigidbody2D>();
		spr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		
	}

	void Update(){
			if (Input.GetKeyDown("q") && isAttacking == false){
            isAttacking = true;

			anim.Play("Player_Attack1");
			
			Invoke("ResetAttack", 0.7f);
		}
	}

		void ResetAttack(){
			isAttacking = false;
		}

	void FixedUpdate(){
		if(Physics2D.Linecast(transform.position, groundCheck.position, whatisGround)){
			isGrounded = true;
		}
		else {
			isGrounded = false;
		}

		if(Input.GetKey("left") || (Input.GetKey("a"))){ //if moves left
			rb.velocity = new Vector2(speed * -1, rb.velocity.y);
		
			if (isGrounded == true && isAttacking == false){
				anim.Play("Player_Run");
			}
		
			facingRight = false;
			transform.localScale = new Vector3(-4, 4, 4);
		} else if (Input.GetKey("right") || (Input.GetKey("d"))){ //if moves right
			rb.velocity = new Vector2(speed, rb.velocity.y);
		
			if (isGrounded == true && isAttacking == false){
			anim.Play("Player_Run");
			}
		
			facingRight = true;
			transform.localScale = new Vector3(4, 4, 4);
		}
		else if (isGrounded == true) {
			if (isAttacking == false){
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
