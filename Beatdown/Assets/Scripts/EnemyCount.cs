using UnityEngine;
using System.Collections;

public class EnemyCount : MonoBehaviour {

	public GameObject enemyHolder;

	// Use this for initialization
	void Start () {
		// If 0: is empty 
		// if 1: is not empty
		PlayerPrefs.SetInt ("isEmpty", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
		// Will find all objects in the hierarchy tagged as Enemy and throw them in this array
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

		// If the array is empty, isEmpty gets set to zero.
		if (enemies.Length == 0) {
			PlayerPrefs.SetInt ("isEmpty", 0);
		}

		if (PlayerPrefs.GetInt ("isEmpty") == 0) {
			enemyHolder.SetActive = false;
		}
	}
}
