using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] 
    private float jumpForce = 400f;							// Amount of force added when the player jumps.
	
	private Rigidbody2D rb;
	private bool facingRight = true;  // For determining which way the player is currently facing.
	private Vector3 velocity = Vector3.zero;

    void Start(){
		rb = GetComponent<Rigidbody2D>();

	}

	private void Update(){
		
	public void Move(float move, bool jump){
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
			
			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !facingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && facingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (jump)
		{
			// Add a vertical force to the player.
			rb.AddForce(new Vector2(0f, jumpForce));
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
