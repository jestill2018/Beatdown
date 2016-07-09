using UnityEngine;
using System.Collections;

public class EnemyBulletCode : MonoBehaviour {


	public GameObject target; 
	public float EnemyBulletSpeed; 
	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void BulletPath() { 
		transform.position = Vector3.MoveTowards (transform.position, target.GetComponent<Rigidbody2D> ().position, EnemyBulletSpeed * Time.deltaTime); 


	} 
}
