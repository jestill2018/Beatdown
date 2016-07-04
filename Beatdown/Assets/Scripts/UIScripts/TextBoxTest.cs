using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxTest : MonoBehaviour {

	public Text dia1;
	public string[] textList = new string[5];
	public int counter;

	public GameObject textBox;

	// Use this for initialization
	void Start () {
		int counter = 0;

		textList [0] = "This is the first text paragraph. Press the spaebar to continue to the second one.";
		textList [1] = "This is the second text paragraph. Press the spaebar to continue to the third one.";
		textList [2] = "This is the third text paragraph. Press the spaebar to continue to the fourth one.";
		textList [3] = "This is the fourth text paragraph. Press the spaebar to continue to the fifth one.";
		textList [4] = "This is the fifth and final text paragraph. Press the spaebar to close the dialogue box.";
	}
	
	// Update is called once per frame
	void Update () {
		dia1.text = textList [counter];

		if (Input.GetKeyDown (KeyCode.Space)) {
			counter += 1;
			if (counter >= 5) {
				textBox.SetActive (false);
				counter = 0;
			}
		}
	}
		
}
