using UnityEngine;
using System.Collections;

public class punching : MonoBehaviour {

	public Object punch1;
	public GameObject player;

	public Vector3 punchVector3;
	public float offset;

	int punches;
	public bool isPunching;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		punches = 0;
		bool punching = false;
	}
	
	// Update is called once per frame
	void Update () {
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
}
