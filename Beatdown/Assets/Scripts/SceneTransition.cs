using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class SceneTransition : MonoBehaviour {

	public string Scene; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D other) { 
		if (other.gameObject.tag == "Player") {

			SceneManager.LoadScene (Scene);
		}
	}
}
