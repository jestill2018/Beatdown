using UnityEngine;
using System.Collections;

public class PlayerMovementV2 : MonoBehaviour 
{
	public Rigidbody2D rb2d;
	public float accel;
	public float maxSpeed;

	Vector2 move;
	Vector2 lastMove;

	public punching punch;

	public bool facingRight;

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		move = new Vector2 (accel, accel) * accel * Time.deltaTime;

		punch = GameObject.Find ("Player").GetComponent<punching> ();

		facingRight = true;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		if (punch.isPunching == false) {

			if (Input.GetKey (KeyCode.W)) {
				rb2d.AddForce (new Vector2 (0, move.y), ForceMode2D.Impulse);
			}

			if (Input.GetKey (KeyCode.S)) {
				rb2d.AddForce (new Vector2 (0, -move.y), ForceMode2D.Impulse);
			}

			if (Input.GetKey (KeyCode.A)) {
				rb2d.AddForce (new Vector2 (-move.x, 0), ForceMode2D.Impulse);
			}

			if (Input.GetKey (KeyCode.D)) {
				rb2d.AddForce (new Vector2 (move.x, 0), ForceMode2D.Impulse);
			}

			if (rb2d.velocity.magnitude > maxSpeed) {
				rb2d.velocity = Vector2.ClampMagnitude (rb2d.velocity, maxSpeed);
			}

			if (rb2d.velocity.magnitude != 0) {
				lastMove = rb2d.velocity;
			}

			if (Input.GetKeyDown (KeyCode.Space)) {
				Vector2 dir = (Vector2)rb2d.transform.position + lastMove.normalized;
				float angle = Mathf.Atan2 (dir.x, dir.y) * Mathf.Rad2Deg;

			}
		}

		Vector3 Scale = transform.localScale;

		if (GetComponent<Rigidbody2D>().velocity.x > 0 && !facingRight) {
			Flip (Scale);
		}
		if (GetComponent<Rigidbody2D>().velocity.x < 0 && facingRight) {
			Flip (Scale);
		}
	}



	public Vector2 getPosition()
	{
		return rb2d.transform.position;
	}


	//....................Flip....................//
	/* This code flips the player character by chaning the scale between 1 for right
	 * and -1 for left.
	 */

	void Flip (Vector3 Scale) 
	{
		//Calculator for how much the character should rotate on his axis to face the other way.
		facingRight = !facingRight;
		Scale.x *= -1; //NOTICE, If you want immediate respawn, you MUST reset this variable to it's original state.
		transform.localScale = Scale;
	}
} 