using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {


	public Transform target; 
	public float speed = 3f; 
	public bool spotted; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (spotted == true) {
			Chase (); 
		}
	}

	void OnTriggerEnter2D(Collider2D other) { 

		if (other.gameObject.tag == "Player") {
			spotted = true; 

		}
	}

	void OnTriggerExit2D(Collider2D other) { 

		if (other.gameObject.tag == "Player") {
			spotted = false; 

		}
	}

	void Chase() { 

		transform.LookAt (target.position); 
		transform.Rotate (new Vector3 (0, -90, 0), Space.Self); 

		if (Vector3.Distance (transform.position, target.position) > 1f) {
			transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );			
		}
	} 
}
