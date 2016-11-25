using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyEvent : MonoBehaviour {

	public Text action;

	public ShipBehavior shipBehavior;
	public GameController gameController;
	public EnemyEvent enemyEvent;

	public float mineChance;
	public float smallAsteroidChance;
	public int shipTargets = 0;

	public GameObject canvas;
	public GameObject asteroidPrefab;
	public GameObject shipResults;
	public GameObject spawnLocation;



	public void SpawnAsteroid ()
	{
		float asteroidType = Random.value;
		if (asteroidType <= smallAsteroidChance) {
			// Spawns small asteroud and has the ship attempt to dodge it
			shipBehavior.checkDodge ();
		} else {
			shipBehavior.clearAction ();

			//Spawn big asteroid and assign objects or scripts to it
			GameObject bigAsteroid = Instantiate (asteroidPrefab, spawnLocation.transform.position, Quaternion.identity) 
		as GameObject;

			bigAsteroid.transform.SetParent (canvas.transform);
			bigAsteroid.GetComponent<BigAsteroidBehavior> ().gameController = gameController;
			bigAsteroid.GetComponent<BigAsteroidBehavior> ().enemyEvent = enemyEvent;

			shipTargets += 1;
			shipBehavior.checkForTargets();

		}
	}

	public void SpawnDrone ()
	{
		float droneType = Random.value;
		if (droneType <= mineChance) {
			shipBehavior.checkDodge ();
		} else {
		Debug.Log("Attack Drone!");
		shipBehavior.clearAction();
		}
	}


}
