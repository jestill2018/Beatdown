using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

	public int npcNum;

	public Text dialogue;
	public GameObject textBox;
	public GameObject NPC;
	public GameObject player;

	public string[] textList;
	public int counter;

	bool isOpen;

	// Use this for initialization
	void Start () {
		counter = 0;
		isOpen = false;

		switch (npcNum) {
		case 1:
			textList [0] = "Hello, my name is Dirty Dan.";
			textList [1] = "If you see Pinhead anywhere, tell him this:";
			textList [2] = "Fuck off";
			break;
		case 2:
			textList [0] = "Mah namez Pinhead, now get outta mah faze.";
			textList [1] = "I said screw off ya panzy.";
			break;
		default:
			textList[0] = "Default text 1";
			textList[1] = "Default text 2";
			textList[2] = "Default text 3";
			textList[3] = "Default text 4";
			textList[4] = "Default text 5";
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<BoxCollider2D> ().bounds.Intersects (gameObject.GetComponent<BoxCollider2D> ().bounds)) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				textBox.SetActive (true);
			}
		}

		dialogue.text = textList [counter];

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (isOpen) {
				counter += 1;
			}
			if (counter >= textList.Length) {
				textBox.SetActive (false);
				counter = 0;
			}
		}

		if (textBox.activeSelf) {
			isOpen = true;
		} else if (textBox.activeSelf == false) {
			isOpen = false;
		}

	}
}
		
