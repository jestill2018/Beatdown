using UnityEngine;
using System.Collections;

public class Bullet_Movement : MonoBehaviour {
		
	/*void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "Wall") {
			Destroy (gameObject, 0);
		}
	}*/

	// Update is called once per frame
	void Update () {
		//transform.Translate (Vector2.right * 10 * Time.deltaTime);
		transform.Translate (Vector3.forward * 50 * Time.deltaTime);

		if (transform.position.x > 10 || Collider.Equals(gameObject, GameObject.Find("Wall"))) {
			Destroy (gameObject, 1);
		}
	}
}
