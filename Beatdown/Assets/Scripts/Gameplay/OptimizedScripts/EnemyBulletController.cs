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
			PlayerHealthManager.DamagePlayerCalculator (damageToGivePlayer);
			Destroy (gameObject);
		}

		if (other.tag == "Middleground") {
			Destroy (gameObject);
		}
	}
}