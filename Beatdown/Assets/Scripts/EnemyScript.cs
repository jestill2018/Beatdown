using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {


	public Transform target; 
	public float speed = 3f; 
	public bool CloseSpotted; 
	public bool shouldBeShooting; 
	public enum State { 
		Far, 
		Close, 
		NotChasing

	}

	public GameObject EnemyBullet; 
	public Transform EnemyBulletSpawn; 

	public State state; 

	// Use this for initialization
	void Start () {
		state = State.NotChasing;

	}
	
	// Update is called once per frame
	void Update () {
		if(state == State.Far) {
			//print ("state is far");
			Chase (); 
		}

		if (state == State.NotChasing) { 
		print ("state is not chasing");
		}

		CloseRangeShift ();
		LongRangeShift ();
		Shoot ();
	}
		

	void NotSeenState() { 
		if (Vector3.Distance (transform.position, target.position) > 21f) {
			state = State.NotChasing; 
		}

	}

	void CloseRangeShift() { 
		if (Vector3.Distance (transform.position, target.position) < 5f) {
			state = State.Close; 
			print ("Close Range");
		}

	}

	void LongRangeShift() { 
		if (Vector3.Distance (transform.position, target.position) < 20f) {
			state = State.Far; 
			print ("Distance State is far");

		}
	}

	void Chase() { 
		transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime); 
	}

	void Shoot() { 
		while (state == State.Far) { 
			Instantiate (EnemyBullet, EnemyBulletSpawn.position, EnemyBulletSpawn.rotation);
		}


	} 
}
