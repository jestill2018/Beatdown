using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {
	public static float maxPlayerHealth; //MUST be a float so that it can be converted to percentages in the health bar.
	public static float currentPlayerHealth; 
	public Transform healthBarFill;
	public Transform healthPercentageIndicator;
	public bool isDead;
	public static float healthSmoothing;
	public static float calculatedHealth;


	void Start () {
		maxPlayerHealth = 100;
		currentPlayerHealth = maxPlayerHealth;
		calculatedHealth = maxPlayerHealth;
		isDead = false;
	}
		
	void Update () {
		HealthManager ();
	}

	//.............Health Manager............//
	/* The players health is displayed and it
	 * checks if the player's health has dropped
	 * to zero. If the players health has dropped
	 * to zero this method will trigger the respawn
	 * method over in the LevelManagemer script
	 */

	void HealthManager ()
	{
		print (currentPlayerHealth);
		if (currentPlayerHealth <= 0.9f && !isDead) { //The <= 0.9 is so that if the player's health falls anywhere below 1 then they have died. The !isDead is so that it doesn't execute again once the player has died.
			currentPlayerHealth = 0; // this makes it so that the health percentage is NEVER less than zero.
			//			levelManager.RespawnPlayer (); //Calls on the method in the LevelManager script to make the player respawn.
			isDead = true; //To prevent the code from killing the player multiple times before the player actually respawns.
		}

		if (currentPlayerHealth > maxPlayerHealth) { //This keeps the player health from going over the max health when they pick up a recovery item.
			currentPlayerHealth = maxPlayerHealth;
		}

		healthPercentageIndicator.GetComponent<Text> ().text = ((int)currentPlayerHealth).ToString () + "%"; //Used to change the text of the health bar that displays the percentage.
		healthBarFill.GetComponent<Image> ().fillAmount = currentPlayerHealth / 100; //Used to change the health bar

		currentPlayerHealth = Mathf.SmoothDamp (currentPlayerHealth, calculatedHealth, ref healthSmoothing, 0.3f); // This line of code is what gradually changers the Health bar.
	}



	//.............Damage Calculator............//
	/* This method calculates the damage that the player
	 * recieves based on the damage output recieved from the enemy bullets/attacks.
	 * This method takes in the damage value of the bullet
	 * and subtracts it from the currentPlayerHealth so that then the
	 * TotalHealthCalculator method knows to what value it has to smooth
	 * the playerhealth towards.
	 * Also, because it is a one time trigger based on 
	 * coming into contact with an enemy attack, it triggers
	 * the sequence that makes the player flicker.
	 */
	public static void DamagePlayerCalculator (float damageToRecievePlayer)
	{
			calculatedHealth = currentPlayerHealth - damageToRecievePlayer;
	}






	//.............Heal Calculator............//
	/* In this method, the value of an energizer is recieved and added to
	 * the players current health. That total is then equalled to the
	 * calculatedHealth which is used to smooth the playerhealth bar up and
	 * down in values depending on whether they have been damaged or healed. This
	 * method takes care of the calculations for when the player is healed.
	 */
	public static void HealPlayerCalculator (float healToRecievePlayer)
	{
		if (currentPlayerHealth < maxPlayerHealth) {
			calculatedHealth = currentPlayerHealth + healToRecievePlayer;
		}
	}






	//.............Health Reset............//
	/* When the player dies, the LevelManager script
	 * resets the health back to normal by triggering
	 * this method.
	 */
	public void FullHealth(){
		calculatedHealth = maxPlayerHealth;
		currentPlayerHealth = maxPlayerHealth;
	}
}
