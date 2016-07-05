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
	}
		

	/*void OnTriggerEnter2D(Collider2D other) { 

		if (other.gameObject.tag == "Player") {
			state = State.Far; 
			shouldBeShooting = true; 

		}
	}*/

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

	/*void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") { 
			CloseSpotted = true;
			shouldBeShooting = false; 
		}

	}

	void OnTriggerExit2D(Collider2D other) { 

		if (other.gameObject.tag == "Player") {
			state = State.NotChasing; 

		}
	}*/
	void Chase() { 
		transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime); 

		/*if (Vector3.Distance (transform.position, target.position) > 1f) {
			transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );			
		}*/
	}

	void Shoot() { 
		if (shouldBeShooting == true) { 
			//instantiate own bullet and send it towards player

		}


	} 
}
