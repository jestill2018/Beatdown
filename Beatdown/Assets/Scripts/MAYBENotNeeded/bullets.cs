using UnityEngine;
using System.Collections;

public class bullets : MonoBehaviour
{

	public Object bulletR;
	public Object bulletL;
	public GameObject player;

	public Rigidbody2D rb2d;

	public int bullPos;
	public float accel;

	Vector2 move;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");
		//bulletR = Instantiate (Resources.Load ("BulletRight"), player.transform.position, Quaternion.identity);
		//bulletL = Instantiate (Resources.Load ("BulletLeft"), player.transform.position, Quaternion.identity);

		//bullPos = player.transform.position;
		move = new Vector2 (accel, accel) * accel * Time.deltaTime;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		/*if (Input.GetKey (KeyCode.P)) {
			Instantiate (bullet, player.transform.position, Quaternion.identity);
		} */

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			Instantiate (bulletR, player.transform.position, Quaternion.identity);
		}
			else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			Instantiate (bulletL, player.transform.position, Quaternion.identity);
		}
		//rb2d.AddForce (new Vector2 (Input.mousePosition.x, Input.mousePosition.y), ForceMode2D.Impulse);
	}
}
