using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;  

public class OnClick : MonoBehaviour {


	public GameObject SettingsPanel; 
	public GameObject PlayPanel; 
	public GameObject CreditsPanel; 
	public GameObject Disk; 
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	//Start of Primary Disc Controls

	public void PlayButton() { 

		PlayPanel.SetActive (true); 
	}

	public void SettingsButton() { 
		SettingsPanel.SetActive (true); 

	}

	public void QuitButton() { 

		Application.Quit ();
	}

	public void CreditsButton() {
		CreditsPanel.SetActive (true); 
	}

	public void RotateRight() { 
		Disk.transform.Rotate (0, 0, 90);

	} 

	public void RotateLeft() { 
		Disk.transform.Rotate (0, 0, -90);


	}

	//End of Primary Disc Controls. 


	//Beginning of Play Panel Controls 
	public void PlayToMain() { 
		PlayPanel.SetActive (false); 

	} 

	public void NewGame() { 
		SceneManager.LoadScene ("gameplayTest"); 

	}

	public void LoadGame() {


	}

	//End of Play Panel Controls 

	//Start of Settings Controls

	public void SettingsToMain() { 
		SettingsPanel.SetActive (false); 

	}

	//Not in use as of yet
	public void SoundControls() { 


	}

	//End of Settings Controls 

	//Start of Credits Controls
	public void CreditsToMain() { 
		CreditsPanel.SetActive (false); 

	} 


	//End of Credits Controls






}
