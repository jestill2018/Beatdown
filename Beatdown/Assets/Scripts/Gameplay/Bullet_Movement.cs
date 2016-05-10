using UnityEngine;
using System.Collections;

public class Bullet_Movement : MonoBehaviour {

	public float accel;
	public float maxSpeed;

	public GameObject player;

	public Rigidbody2D rb2d;

	Vector2 direction;

	Vector2 move;

	void Start() {
		move = new Vector2 (accel, accel) * accel * Time.deltaTime;
		rb2d = GetComponent<Rigidbody2D> ();

		player = GameObject.Find ("Player");
	}

	/*void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "Wall") {
			Destroy (gameObject, 0);
		}
	}*/

	void Update() {
		Debug.Log ("x: " + Input.mousePosition.x);
		Debug.Log("y: " + Input.mousePosition.y);
	}

	// Update is called once per frame
	void FixedUpdate () {
		//direction = (Input.mousePosition - player.transform.position).normalized;
	
		//rb2d.AddForce (new Vector2 (Input.mousePosition.x * accel, Input.mousePosition.y * accel) * Time.deltaTime, ForceMode2D.Impulse);

		if (Input.GetKey (KeyCode.UpArrow)) {
			rb2d.AddForce (new Vector2 (0, move.y), ForceMode2D.Impulse);
		} 	else if (Input.GetKey (KeyCode.DownArrow)) {
			rb2d.AddForce (new Vector2 (0, -move.y), ForceMode2D.Impulse);
		} 	else if (Input.GetKey (KeyCode.RightArrow)) {
			rb2d.AddForce (new Vector2 (0, move.x), ForceMode2D.Impulse);
		} 	else if (Input.GetKey (KeyCode.LeftArrow)) {
			rb2d.AddForce (new Vector2 (0, -move.x), ForceMode2D.Impulse);
		}
	}
}
