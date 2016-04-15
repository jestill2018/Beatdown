using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public Rigidbody2D rb2d;
	public float accel;
	public float maxSpeed;

	Vector2 move;
	Vector2 lastMove;

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		move = new Vector2 (accel, accel) * accel * Time.deltaTime;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{

		if (Input.GetKey (KeyCode.W)) {
			rb2d.AddForce (new Vector2 (0, move.y), ForceMode2D.Impulse);
		}

		if (Input.GetKey (KeyCode.S)) {
			rb2d.AddForce (new Vector2 (0, -move.y), ForceMode2D.Impulse);
		}

		if (Input.GetKey (KeyCode.A))
		{
			rb2d.AddForce (new Vector2 (-move.x, 0), ForceMode2D.Impulse);
		}

		if(Input.GetKey(KeyCode.D)) 
		{
			rb2d.AddForce (new Vector2(move.x,0),ForceMode2D.Impulse);
		}

		if (rb2d.velocity.magnitude > maxSpeed)
		{
			rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity,maxSpeed);
		}

		if (rb2d.velocity.magnitude != 0)
		{
			lastMove = rb2d.velocity;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			Vector2 dir = (Vector2) rb2d.transform.position + lastMove.normalized;
			float angle = Mathf.Atan2 (dir.x, dir.y) * Mathf.Rad2Deg;

		}
	}

	public Vector2 getPosition()
	{
		return rb2d.transform.position;
	}
} 