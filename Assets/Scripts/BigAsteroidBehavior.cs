using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BigAsteroidBehavior : MonoBehaviour {

	public float minHealth;
	public float maxHealth;
	public float timeToImpact;
	public float bigAsteroidSpeed;

	public Text health;
	public Text impactTime;
	public Text shipResult;

	public GameController gameController;
	public EnemyEvent enemyEvent;

	float setHealth;

	void Start () {
	//Set initial values for large asteroid
	setHealth = Mathf.Round(Random.Range(minHealth, maxHealth +1));
	InvokeRepeating("countdown", gameController.gameDelay, gameController.gameSpeed);
	}

	void Update ()
	{
		//Update current HP and distance to player
		health.text = setHealth.ToString ();
		impactTime.text = timeToImpact.ToString ();

		//Check if it is time to collide with the player
		if (timeToImpact <= 0) {
			collideWithPlayer ();
		} else {
			moveAsteroid();
		}
	}

	void countdown ()
	{
		timeToImpact-= 1;
	}

	void collideWithPlayer ()
	{
		destroyAsteroid();
	}

	void moveAsteroid()
	{
		transform.position += Vector3.down * bigAsteroidSpeed * Time.deltaTime;
	}

	//Damage the asteroid
	void OnTriggerEnter2D (Collider2D collider)
	{
		AutoProjectile autoLaser = collider.gameObject.GetComponent<AutoProjectile> ();
		if (autoLaser) {
			setHealth -= autoLaser.GetDamage ();
			autoLaser.Hit();
			if (setHealth <= 0) {
			destroyAsteroid();
			}
		}
	}

	void destroyAsteroid ()
	{
		Destroy(gameObject);
		enemyEvent.shipTargets -= 1;
	}

}
