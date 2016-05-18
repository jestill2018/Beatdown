using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;  

public class OnClickSceneTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		PlayButton (); 
	}

	void PlayButton() { 
		SceneManager.LoadScene ("gameplay");
	}

	void SettingsButton() { 


	}

	void QuitButton() { 


	}

	void CreditsButton() {


	}

	void RotateRight() { 


	} 

	void RotateLeft() { 


	}




}
