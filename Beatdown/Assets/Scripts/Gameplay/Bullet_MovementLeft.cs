using UnityEngine;
using System.Collections;

public class Bullet_MovementLeft : MonoBehaviour {
		
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "Wall") {
			Destroy (gameObject, 0);
		}
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.left * 100 * Time.deltaTime);

		if (transform.position.x < -25) {
			Destroy (gameObject, 1);
		}
	}
}
