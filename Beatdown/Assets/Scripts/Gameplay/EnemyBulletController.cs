using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour {

	public EnemyController enemy;
	public float speed;
	float lifeTimer;
	public float lifeTimerLimit;
	public float damageToGivePlayer;


	void Start () {
		enemy = FindObjectOfType<EnemyController> ();

		if (enemy.transform.localScale.x < 0) {
			speed = -speed;
		}

		//print (enemy.transform.localScale.x);
	}

	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);

		lifeTimer += Time.deltaTime;

		if (lifeTimer > lifeTimerLimit) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			PlayerController.DamagePlayerCalculator (damageToGivePlayer);
			Destroy (gameObject);
		}
	}
}