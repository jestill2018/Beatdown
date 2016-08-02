using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour {

	public EnemyController enemy;
	public float speed;
	float lifeTimer;
	public float lifeTimerLimit;
	public float damageToGivePlayer;
	public Vector3 PlayerPositionAtSpawn; 
	public GameObject Player; 

	void Start () {
		Player = GameObject.FindWithTag ("Player"); 
		enemy = FindObjectOfType<EnemyController> ();

		if (enemy.transform.localScale.x < 0) {
			speed = -speed;
		}

		PlayerPositionAtSpawn = Player.transform.position;

		//print (enemy.transform.localScale.x);
	}

	void Update () {
	//	GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);

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