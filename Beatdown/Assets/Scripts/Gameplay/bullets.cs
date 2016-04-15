using UnityEngine;
using System.Collections;

public class bullets : MonoBehaviour {

	public Object bullet;
	public GameObject player;

	public Rigidbody2D rb2d;

	public int bullPos;
	public float accel;

	Vector2 move;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		bullet = Instantiate (Resources.Load ("Bullet"), player.transform.position, Quaternion.identity);

		//bullPos = player.transform.position;
		move = new Vector2(accel, accel) * accel * Time.deltaTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.P)) {
			Instantiate (bullet, player.transform.position, Quaternion.identity);
		}

		//rb2d.AddForce (new Vector2 (Input.mousePosition.x, Input.mousePosition.y), ForceMode2D.Impulse);
		rb2d.velocity = transform.TransformDirection (Vector3.forward * accel);
	}
}
