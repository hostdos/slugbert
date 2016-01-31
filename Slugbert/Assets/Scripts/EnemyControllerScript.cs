using UnityEngine;
using System.Collections;

public class EnemyControllerScript : MonoBehaviour {


	public Transform Player;
	public float moveSpeed = 2f;
	public float maxDist = 30f;
	public float minDist = 2f;
	bool facingRight = true;



	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate () {


		if(Vector2.Distance(transform.position,Player.position) >= minDist){

			//GetComponent<Rigidbody2D>().velocity = new Vector2 (Vector2.Distance(transform.position,Player.position) * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

			Vector3 vectorToTarget = Player.position - transform.position;
			transform.position += vectorToTarget.normalized * moveSpeed * Time.deltaTime;

			if (vectorToTarget.x > 0 && !facingRight)
				Flip ();
			else if (vectorToTarget.x < 0 && facingRight)
				Flip ();

			if(Vector2.Distance(transform.position,Player.position) <= maxDist)
			{
				//Here Call any function U want Like Shoot at here or something
			} 

		}

	}


	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}