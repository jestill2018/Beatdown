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
	public float PunchSpawnTimer = 3f; 
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
	
		//Punch Position Determination
		if (RightBox.facingRight == true) {
			PunchPosition = new Vector3 (transform.position.x + 3f, transform.position.y);
		}
		if (LeftBox.facingLeft == true) { 
			PunchPosition = new Vector3 (transform.position.x - 3f, transform.position.y);
		}
		//End of Punch Position Determination

		//State Transitions and function calls 

		NotSeenState ();
		LongRangeShift ();
		CloseRangeShift ();
		MeleeProximityShift ();
		EnemyHealth ();


		if (state == State.NotChasing) { 
			//Set up for idle animation to be put here
		}

		if(state == State.Far) {
			LongRangeBehaviours();
			ShootTimer -= Time.deltaTime; 
		}
			
		if (state == State.Close) { 
			CloseRangeBehaviours(); 
		}

		if (state == State.MeleeProximity) {
			MeleeRangeBehaviours (); 
			PunchSpawnTimer -= Time.deltaTime; 
		 
		}
			


	}


	//State Shift parameters
	void NotSeenState() { 
		if (Vector3.Distance (transform.position, target.position) > 50f) {
			state = State.NotChasing; 
		}

	}
		
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
		}
	} 
	//End of state shift parameteres



	//State Behaviour Holders
	void LongRangeBehaviours() { 
		if (ShootTimer <= 0) {
			Shoot ();
			ShootTimer = 0.5f; 
		}
	} 
		
	void CloseRangeBehaviours() { 
		Chase ();
	}


	void MeleeRangeBehaviours() { 
		Punch (); 
	}

	//State Behaviour Holders end



	//Behaviour Functions
	void Chase() { 
		transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime); 
	}

	void Shoot() { 
		
			Instantiate (EnemyBullet, EnemyBulletSpawn.position, EnemyBulletSpawn.rotation);
	} 

	void Punch() { 
		if (PunchSpawnTimer <= 0) { 
			Instantiate (EnemyPunchSprite, PunchPosition, EnemyBulletSpawn.rotation);
			PunchSpawnTimer = 3f; 
		}
		 

	}
	//Behviour Functions End



	//Other 
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





}
