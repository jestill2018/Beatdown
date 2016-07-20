using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Movement Start
	public Rigidbody2D rb2d;
	public float accel;
	public float maxSpeed;
	Vector2 move;
	Vector2 lastMove;

	public bool facingRight;
	//Movement End


	//Player Health Starts 
	public static float maxPlayerHealth; //MUST be a float so that it can be converted to percentages in the health bar.
	public static float currentPlayerHealth; 
	public Transform healthBarFill;
	public Transform healthPercentageIndicator;
	public bool isDead;
	public static float healthSmoothing;
	public static float calculatedHealth;
	//Player Health Ends

	//Bullet Control Starts
	public Transform firePoint;
	public GameObject bullet;
	//Bullet Control Ends


	//Punching Begins
	public Object punch1;
	public GameObject player;

	public Vector3 punchVector3;
	public float offset;

	int punches;
	public bool isPunching;
	//Punching Ends

	public LevelManager levelManager;


	void Start () {
	//Movement Start 
		rb2d = GetComponent<Rigidbody2D> ();
		move = new Vector2 (accel, accel) * accel * Time.deltaTime;

		facingRight = true;
	//Movement End

	//Player Health Starts 
		maxPlayerHealth = 100;
		currentPlayerHealth = maxPlayerHealth;
		calculatedHealth = maxPlayerHealth;
		isDead = false;
	//Player Health Ends

	//Punching Begins
		player = GameObject.Find ("Player");
		punches = 0;
		bool punching = false;
	//Punching Ends

		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (isPunching == false) 
		{
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
	
				


		if (Input.GetKeyDown (KeyCode.Space)) 
		
		{
			Instantiate (bullet, firePoint.position, firePoint.rotation);
		}


		Vector3 Scale = transform.localScale;

		if (GetComponent<Rigidbody2D> ().velocity.x > 0 && !facingRight) 
		{
			Flip (Scale);
		}
		if (GetComponent<Rigidbody2D> ().velocity.x < 0 && facingRight) 
		{
			Flip (Scale);
		}

		HealthManager ();

		punchVector3 = new Vector3(player.transform.position.x + offset, player.transform.position.y);

		if (Input.GetKeyDown (KeyCode.E)) {
			Instantiate (punch1, punchVector3, Quaternion.identity);
			punches += 1;
			isPunching = true;
		} else if (Input.GetKeyUp (KeyCode.E)) {
			Destroy (GameObject.Find ("punch1(Clone)"), 0);
			isPunching = false;
		}
	}



	public Vector2 getPosition()
	{
		return rb2d.transform.position;
	}

	void Flip (Vector3 Scale) 
	{
		//Calculator for how much the character should rotate on his axis to face the other way.
		facingRight = !facingRight;
		Scale.x *= -1; //NOTICE, If you want immediate respawn, you MUST reset this variable to it's original state.
		transform.localScale = Scale;
	}

	void HealthManager ()
	{
		if (currentPlayerHealth <= 0.9f && !isDead) { //The <= 0.9 is so that if the player's health falls anywhere below 1 then they have died. The !isDead is so that it doesn't execute again once the player has died.
			currentPlayerHealth = 0; // this makes it so that the health percentage is NEVER less than zero.
			levelManager.RespawnPlayer (); //Calls on the method in the LevelManager script to make the player respawn.
			isDead = true; //To prevent the code from killing the player multiple times before the player actually respawns.
		}

		if (currentPlayerHealth > maxPlayerHealth) { //This keeps the player health from going over the max health when they pick up a recovery item.
			currentPlayerHealth = maxPlayerHealth;
		}

		healthPercentageIndicator.GetComponent<Text> ().text = ((int)currentPlayerHealth).ToString () + "%"; //Used to change the text of the health bar that displays the percentage.
		healthBarFill.GetComponent<Image> ().fillAmount = currentPlayerHealth / 100; //Used to change the health bar

		currentPlayerHealth = Mathf.SmoothDamp (currentPlayerHealth, calculatedHealth, ref healthSmoothing, 0.3f); // This line of code is what gradually changers the Health bar.
	}



	//.............Damage Calculator............//
	/* This method calculates the damage that the player
	 * recieves based on the damage output recieved from the enemy bullets/attacks.
	 * This method takes in the damage value of the bullet
	 * and subtracts it from the currentPlayerHealth so that then the
	 * TotalHealthCalculator method knows to what value it has to smooth
	 * the playerhealth towards.
	 * Also, because it is a one time trigger based on 
	 * coming into contact with an enemy attack, it triggers
	 * the sequence that makes the player flicker.
	 */
	public static void DamagePlayerCalculator (float damageToRecievePlayer)
	{
		calculatedHealth = currentPlayerHealth - damageToRecievePlayer;
	}



	//.............Heal Calculator............//
	/* In this method, the value of an energizer is recieved and added to
	 * the players current health. That total is then equalled to the
	 * calculatedHealth which is used to smooth the playerhealth bar up and
	 * down in values depending on whether they have been damaged or healed. This
	 * method takes care of the calculations for when the player is healed.
	 */
	public static void HealPlayerCalculator (float healToRecievePlayer)
	{
		if (currentPlayerHealth < maxPlayerHealth) {
			calculatedHealth = currentPlayerHealth + healToRecievePlayer;
		}
	}



	//.............Health Reset............//
	/* When the player dies, the LevelManager script
	 * resets the health back to normal by triggering
	 * this method.
	 */
	public void FullHealth(){
		calculatedHealth = maxPlayerHealth;
		currentPlayerHealth = maxPlayerHealth;
	}
}



