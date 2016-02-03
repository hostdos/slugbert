using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

	public float moveSpeed = 10f;
	public float airSpeed = 12f;
	bool facingRight = true;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	private Animator animator;

	public float jumpForce = 260f;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// FixedUpdate is used for rigidbody manipulation
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);



		float move = Input.GetAxis ("Horizontal");
		if(grounded)
			GetComponent<Rigidbody2D>().velocity = new Vector2 (move * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		else if (!grounded)
			GetComponent<Rigidbody2D>().velocity = new Vector2 (move * airSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
		
	}

	void Update() {

		if (grounded && Input.GetKeyDown (KeyCode.Space))  //replace this with redefinable button variable
		{
			animator.SetBool ("playerWalk", false);
			animator.SetTrigger ("playerJump");
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
		}

		if (grounded && GetComponent<Rigidbody2D> ().velocity.x != Vector2.zero.x) {
			animator.SetBool ("playerWalk", true);
		} else if (!grounded) {
			animator.SetBool ("playerWalk", false);
		}
		
		if (GetComponent<Rigidbody2D> ().velocity == Vector2.zero){
			animator.SetBool ("playerWalk", false);
		}

	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}