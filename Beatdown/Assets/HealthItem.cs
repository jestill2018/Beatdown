using UnityEngine;
using System.Collections;

public class HealthItem : MonoBehaviour {

	public PlayerController player;
	float lifeTime;
	public float lifeTimeLimit;
	public float healthToGivePlayer;

	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}

	void Update () {

		lifeTime += Time.deltaTime;

		if (lifeTime > lifeTimeLimit) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			print ("COLLIDING WITH PLAYER");
			PlayerController.HealPlayerCalculator (healthToGivePlayer); //This line of code passes on to the player script the amount of health that this particular energizer heals.
			Destroy (gameObject);
		}
	}
}
