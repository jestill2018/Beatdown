using UnityEngine;
using System.Collections;

public class TransformationController : MonoBehaviour {

	public bool isFacingRight;
	public Object punch1;
	public GameObject player;

	public Vector3 punchVector3;
	public float offset;

	public Rigidbody2D rb2d;
	public float accel;
	public float maxSpeed;

	Vector2 move;
	Vector2 lastMove;

	int punches;
	public bool isPunching;
	public static bool Normal; 
	public static bool Country;
	public static  bool Metal;
	public static bool Pop;
	public static bool Classical;
	public static bool Edm; 
	public GameObject TransformationPanel; 
	public Sprite NormalSprite; 
	public Sprite CountrySprite; 

	public Object bulletR;
	public Object bulletL;

	public Rigidbody2D Bulletrb2d;

	public int bullPos;
	public float Bulletaccel;

	Vector2 Bulletmove;

	public int PunchCounter;



	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		punches = 0;
		bool punching = false;
		Normal = true; 
		Bulletmove = new Vector2 (accel, accel) * accel * Time.deltaTime;
		rb2d = player.GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			Instantiate (bulletR, player.transform.position, Quaternion.identity);
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			Instantiate (bulletL, player.transform.position, Quaternion.identity);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			TransformationPanel.SetActive (true);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			TransformationPanel.SetActive (false);
		}

		punchVector3 = new Vector3(player.transform.position.x + offset, player.transform.position.y);

		if (Input.GetKey (KeyCode.E)) {
			PunchCounter = 5; 
			Instantiate (punch1, punchVector3, Quaternion.identity);
			punches += 1;
			isPunching = true;
		} else {
			while (PunchCounter > 0) { 
				PunchCounter--;
			}
			if (PunchCounter >= 0) {
				Destroy (GameObject.Find ("punch1(Clone)"), 0);
				isPunching = false;
			}
		}

		if (isPunching == false) {

			if (Input.GetKey (KeyCode.W)) {
				rb2d.AddForce (new Vector2 (0, move.y), ForceMode2D.Impulse);

			}

			if (Input.GetKey (KeyCode.S)) {
				rb2d.AddForce (new Vector2 (0, -move.y), ForceMode2D.Impulse);
			}

			if (Input.GetKey (KeyCode.A)) {
				rb2d.AddForce (new Vector2 (-5, 0), ForceMode2D.Impulse);
				isFacingRight = false; 
				print (isFacingRight);
			}

			if (Input.GetKey (KeyCode.D)) {
				rb2d.AddForce (new Vector2 (5, 0), ForceMode2D.Impulse);
				isFacingRight = true; 
				print (isFacingRight);

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
	}

	public Vector2 getPosition()
	{
		return rb2d.transform.position;
	}
		




	//Transformation Code Below



	public void NormalTransformation () { 
		Normal = true; 
		Country = false; 
		Metal = false; 
		Pop = false; 
		Classical = false; 
		Edm = false; 

		if (Normal == true) { 
			gameObject.GetComponent<SpriteRenderer> ().sprite = NormalSprite; 

		}
	}

	public void CountryTransformation() {
		Country = true; 
		Metal = false; 
		Pop = false; 
		Classical = false; 
		Edm = false; 
		Normal = false;
		if (Country == true) { 
			gameObject.GetComponent<SpriteRenderer> ().sprite = CountrySprite; 

		}
	}

	public void MetalTransofrmation() { 
		Metal = true; 
		Pop = false; 
		Classical = false; 
		Edm = false; 
		Normal = false;
		Country = false; 
	}

	public void PopTransformation() { 
		Pop = true; 
		Classical = false; 
		Edm = false; 
		Normal = false;
		Country = false;
		Metal = false;
	} 

	public void ClassicalTransformation() { 
		Classical = true; 
		Edm = false; 
		Normal = false;
		Country = false;
		Metal = false;
		Pop = false; 
	} 

	public void EdmTransformation() { 
		Edm = true; 
		Normal = false;
		Country = false;
		Metal = false;
		Pop = false; 
		Classical = false; 
	} 


}
