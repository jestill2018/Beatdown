using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	//public Vector2 BoxCastStartPoint; 
	//public Vector2 BoxCastSizeOfArea;
//	public float BoxCastAngle; 


	//public bool RayCastPlayerIsRight = false; 
	public Transform target; 
	public float speed = 3f; 
	public bool CloseSpotted; 
	public bool shouldBeShooting; 
	private float ShootTimer = 0.5f; 

	public enum State { 
		Far, 
		Close, 
		NotChasing

	}

	public GameObject EnemyBullet; 
	public Transform EnemyBulletSpawn; 

	public State state; 

	public int enemyHealth;

	public bool facingRight = true;

	void Start () {
		state = State.NotChasing;
		enemyHealth = 100;
	}



	void Update () {
		if(state == State.Far) {
			//print ("state is far");

			ShootTimer -= Time.deltaTime; 

			Chase (); 
			LongRangeShift (); 
		}

		if (state == State.NotChasing) { 
		//	print ("state is not chasing");
		}



		CloseRangeShift ();
		LongRangeShift ();
		EnemyHealth ();
		//print (ShootTimer);


	}


	void NotSeenState() { 
		if (Vector3.Distance (transform.position, target.position) > 21f) {
			state = State.NotChasing; 
		}

	}

	void CloseRangeShift() { 
		if (Vector3.Distance (transform.position, target.position) < 5f) {
			state = State.Close; 
			//print ("Close Range");
		}

	}

	void LongRangeShift() { 
		if (Vector3.Distance (transform.position, target.position) < 20f) {
			state = State.Far; 
			//print ("Distance State is far");
			if (ShootTimer <= 0) {
				Shoot ();
				ShootTimer = 0.5f; 
			}
		}
	}

	void Chase() { 
		transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime); 
	}

	void Shoot() { 
//		while (state == State.Far) { 

	
			Instantiate (EnemyBullet, EnemyBulletSpawn.position, EnemyBulletSpawn.rotation);
	


	} 

	void EnemyHealth ()
	{
		if (enemyHealth <= 0) {
			Destroy (gameObject);
		}
	}




	public void EnemyRecieveDamage (int damageToGive)
	{
		enemyHealth -= damageToGive;
		print (enemyHealth);
	}



}
