using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;
	private PlayerController player;
	public float respawnDelay;

	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}

	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCoroutine");
	}

	public IEnumerator RespawnPlayerCoroutine(){
		//		Instantiate (customDeathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds (respawnDelay); //This holds off the rest of the code until a certain amount of time has passed based on the provided float variable
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true;
		player.FullHealth ();
		player.isDead = false;
		player.GetComponent<Renderer>().enabled = true;
	}
}
