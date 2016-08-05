using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour {

	public EnemyController enemy;
	public float speed;
	float lifeTimer;
	public float lifeTimerLimit;
	public float damageToGivePlayer;
	public Vector3 PlayerPositionAtSpawn; 
	public Vector3 EnemyBulletSpawnLocation; 

	public GameObject Player; 
	private float StartTime; 
	private float MoveLength; 
	public GameObject BulletSpawnPoint; 





	void Start () {
		Player = GameObject.FindWithTag ("Player"); 
		BulletSpawnPoint = GameObject.FindWithTag ("EnemyBulletSpawn"); 
		enemy = FindObjectOfType<EnemyController> ();

		if (enemy.transform.localScale.x < 0) {
			speed = -speed;
		}

		PlayerPositionAtSpawn = Player.transform.position;
		EnemyBulletSpawnLocation = BulletSpawnPoint.transform.position;
		StartTime = Time.time;
		MoveLength = Vector3.Distance (EnemyBulletSpawnLocation, PlayerPositionAtSpawn);

		//print (enemy.transform.localScale.x);
	}

	void Update () {
	//	GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
		float distanceCovered = (Time.time - StartTime) * speed; 
		float Journey = distanceCovered / MoveLength; 
		transform.position = Vector3.Lerp (EnemyBulletSpawnLocation, PlayerPositionAtSpawn, Journey);
		print (MoveLength);
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