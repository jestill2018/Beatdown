using UnityEngine;
using System.Collections;

public class PlayerBulletController : MonoBehaviour {

	public Transform firePoint;
	public GameObject bullet;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Instantiate (bullet, firePoint.position, firePoint.rotation);
		}
	}
}
