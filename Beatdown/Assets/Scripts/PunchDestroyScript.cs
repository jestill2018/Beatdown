using UnityEngine;
using System.Collections;

public class PunchDestroyScript : MonoBehaviour {

	private float PunchDestroyTimer = 20f; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PunchDestroyTimer--; 
		print ("Punch Destroyer" + PunchDestroyTimer);

		if (PunchDestroyTimer <= 0) { 
			Destroy (gameObject);
		
			PunchDestroyTimer = PunchDestroyTimer;

		} 
	}
}
