using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{

	public GameObject Bullet;
	public GameObject BulletUp;
	public GameObject Player;
	public float xPos;
	public float yPos;
		
	void fireBulletsRight ()
	{
		GameObject bullet = (Instantiate (Bullet, transform.position, transform.rotation)) as GameObject;
		bullet.transform.position = new Vector2 (xPos + 0.80f, yPos);
	}

	/*void fireBulletsUp ()
	{
		if (Combos.getMatch ()) {
			GameObject bulletUp = (Instantiate (BulletUp, transform.position, transform.rotation)) as GameObject;
			bulletUp.transform.position = new Vector2 (xPos, yPos + 0.80f);
		}
	} */

	// Use this for initialization
	void Start ()
	{
		Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{

		xPos = Player.transform.position.x;
		yPos = Player.transform.position.y;	

		// Fires a bullet the moment "E" is pressed, and then stops
		if (Input.GetKeyDown (KeyCode.E)) {
			fireBulletsRight ();

		} 

		/*if (Input.GetKeyDown (KeyCode.Q)) {
			fireBulletsUp (); 
		} */
	}
}
