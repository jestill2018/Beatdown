using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static bool Normal; 
	public static bool Country;
	public static  bool Metal;
	public static bool Pop;
	public static bool Classical;
	public static bool Edm; 
	public GameObject TransformationPanel; 
	public Sprite NormalSprite; 
	public Sprite CountrySprite; 


	// Use this for initialization
	void Start () {
		Normal = true; 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			TransformationPanel.SetActive (true);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			TransformationPanel.SetActive (false);
		}
	}

	public void NormalTransformation () { 
		Normal = true; 
		Country = false; 
		Metal = false; 
		Pop = false; 
		Classical = false; 
		Edm = false; 

		if (Normal == true) { 
			gameObject.GetComponent<SpriteRenderer> ().sprite = NormalSprite; 

		}
	}

	public void CountryTransformation() {
		Country = true; 
		Metal = false; 
		Pop = false; 
		Classical = false; 
		Edm = false; 
		Normal = false;
		if (Country == true) { 
			gameObject.GetComponent<SpriteRenderer> ().sprite = CountrySprite; 

		}
	}

	public void MetalTransofrmation() { 
		Metal = true; 
		Pop = false; 
		Classical = false; 
		Edm = false; 
		Normal = false;
		Country = false; 
	}

	public void PopTransformation() { 
		Pop = true; 
		Classical = false; 
		Edm = false; 
		Normal = false;
		Country = false;
		Metal = false;
	} 

	public void ClassicalTransformation() { 
		Classical = true; 
		Edm = false; 
		Normal = false;
		Country = false;
		Metal = false;
		Pop = false; 
	} 

	public void EdmTransformation() { 
		Edm = true; 
		Normal = false;
		Country = false;
		Metal = false;
		Pop = false; 
		Classical = false; 
	} 


}
