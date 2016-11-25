using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipStats : MonoBehaviour {


	public int shipHP;
	public int shields;
	public int shipLootStart;

	public float shipDodgeChance;
	public float autoLaserDamage;

	public Text shipHPText;
	public Text shipAutoDMGText;
	public Text shipDodgeText;
	public Text shipSields;

	int playerHealth;
	int playerShields;
	float playerAutoDamage;
	float playerDodge;
	
	void Update () {
	//Displaying Ship's Stats
		playerHealth = shipHP;
		shipHPText.text = playerHealth.ToString();

		playerAutoDamage = autoLaserDamage;
		shipAutoDMGText.text = playerAutoDamage.ToString();

		playerDodge = shipDodgeChance;
		shipDodgeText.text = playerDodge.ToString();

	}
}
