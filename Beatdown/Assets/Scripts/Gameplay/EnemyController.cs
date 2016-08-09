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
	public GameObject EnemyPunchSprite; 
	public Vector3 PunchPosition; 
	public float PunchDestroyTimer = 0.5f; 
	public float PunchSpawnTimer = 0.4f; 
	public GameObject PunchHolder; 
	public BoxCastRight RightBox; 
	public BoxCastLeft LeftBox; 




	public enum State { 
		Far, 
		Close, 
		MeleeProximity, 
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
		RightBox = FindObjectOfType<BoxCastRight> ();
		LeftBox = FindObjectOfType<BoxCastLeft> ();

	}



	void Update () {
		if (RightBox.facingRight == true) {
			PunchPosition = new Vector3 (transform.position.x + 3f, transform.position.y);
		}
		if (LeftBox.facingLeft == true) { 
			PunchPosition = new Vector3 (transform.position.x - 3f, transform.position.y);
		}


		if (state == State.NotChasing) { 
			//print ("state is not chasing");
		}

		if(state == State.Far) {
			//print ("state is far");
			LongRangeBehaviours();
			ShootTimer -= Time.deltaTime; 
		}


		if (state == State.Close) { 
			//print ("state is close");
			Chase(); 
		}

		if (state == State.MeleeProximity) {
			CloseRangeBehaviours (); 
			PunchSpawnTimer -= Time.deltaTime; 
			PunchDestroyTimer -= Time.deltaTime; 
		}



		NotSeenState ();
		LongRangeShift ();
		CloseRangeShift ();
		MeleeProximityShift ();

		EnemyHealth ();
	


	}


	void NotSeenState() { 
		if (Vector3.Distance (transform.position, target.position) > 50f) {
			state = State.NotChasing; 
		}

	}


	//Holds long range shift code and actions for enemy AI 
	void LongRangeShift() { 
		if (Vector3.Distance (transform.position, target.position) < 49f) {
			state = State.Far; 
		}
	}

	void CloseRangeShift() { 
		if (Vector3.Distance (transform.position, target.position) < 20f) {
			state = State.Close; 
		}

	}

	void MeleeProximityShift() { 
		if(Vector3.Distance(transform.position, target.position) < 10f) {
			state = State.MeleeProximity;
			print ("should be punchin");
		}

	} 

	void LongRangeBehaviours() { 
		if (ShootTimer <= 0) {
			Shoot ();
			ShootTimer = 0.5f; 
		}
	} 
	//Break Long Range parameters and actoins


	//Holds close range actions for enemy AI


	void CloseRangeBehaviours() { 
		Punch (); 
	}



	void Chase() { 
		transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime); 
	}

	void Shoot() { 
		
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

	}

	void Punch() { 
		if (PunchSpawnTimer <= 0) { 
			Instantiate (EnemyPunchSprite, PunchPosition, EnemyBulletSpawn.rotation);
			PunchSpawnTimer = 0.4f; 
		}
		if (PunchDestroyTimer <= 0) { 
			PunchHolder = (GameObject.FindGameObjectWithTag ("EnemyPunch")); 
			Destroy (PunchHolder);
			PunchDestroyTimer = 0.5f;
		} 




	}



}
