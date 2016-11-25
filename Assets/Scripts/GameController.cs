using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text spaceTimeText;
	public Text lootCount;
	public Text gameEvent;
	public float gameSpeed;
	public float gameDelay;
	public float spawnTimer;

	int timePassed = 0;
	int currentLoot;

	public EnemyEvent enemyEvent;
	public ShipBehavior shipBehavior;
	public ShipStats shipStats;

	void Start () {
		//Gets the ball rolling
		InvokeRepeating("passTime", gameDelay, gameSpeed);
		InvokeRepeating("spawnTime",gameDelay + spawnTimer, spawnTimer);
	}
	
	void Update () {
		//Counts how long the game has been running
		spaceTimeText.text = timePassed.ToString();

		//Update of the amount of loot gained
		currentLoot = shipStats.shipLootStart;
		lootCount.text = currentLoot.ToString();
	}

	void passTime ()
	{
		timePassed+= 1;
	}

	//Decides when it is time to trigger an event
	void spawnTime ()
	{
		int spawnType = Random.Range (1, 5);
		switch (spawnType) {
			case 1:
				gameEvent.text = "Nothing but empty space...";
				shipBehavior.clearAction ();
				break;
			case 2: 
				gameEvent.text = "Hey! Free Loot!";
				shipBehavior.lootSpawn();
				break;
			case 3:
				gameEvent.text = "Asteroid!";
				enemyEvent.SpawnAsteroid();
				break;
			case 4: 
				gameEvent.text = "Drone!";
				enemyEvent.SpawnDrone();
				break;
			default:
				gameEvent.text = "Nothing but empty space...";
				break;
		}

	}

}
