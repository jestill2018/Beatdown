using UnityEngine;
using System.Collections;

public class PlayerBulletV2 : MonoBehaviour {

	public float speed;
	float lifeTime;
	public float lifeTimeLimit;
	public int damageToGive;
	public PlayerController playerMovement;

	void Start () {
		playerMovement = FindObjectOfType<PlayerController> ();

		if (playerMovement.transform.localScale.x < 0) {
			speed = -speed;
		}
	}

	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);

		lifeTime += Time.deltaTime;

		if (lifeTime > lifeTimeLimit) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
//			other.GetComponent<EnemyController>().EnemyRecieveDamage(damageToGive); //This line of code passes on to the enemy script the amount of damage that this particular bullet does to the enemy.
			Destroy (gameObject);
		}
	}
}
