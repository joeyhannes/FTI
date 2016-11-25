using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipBehavior : MonoBehaviour {

	public ShipStats shipStats;
	public EnemyEvent enemyEvent;

	public GameObject autoProjectile;
	public GameObject canvas;

	public Text shipAction;

	public float fireRate;
	public float autoLaserSpeed;

	private bool isFiring = false;


	void Update ()
	{
		if (enemyEvent.shipTargets == 0) {
		stopAutoFire();
		}
	}

	public void checkDodge ()
	{
		float dodgeChance = shipStats.shipDodgeChance;

		if (dodgeChance >= Random.value) {
			shipAction.text = "Dodge Successful!";
		} else {
		shipAction.text = "Damage Taken";
		takeDamage();
		}
	}

	void takeDamage() 
	{
		shipStats.shipHP -= 5;
	}

	public void lootSpawn ()
	{
		int lootDropped = Random.Range(1,4);
		shipStats.shipLootStart += lootDropped;
		shipAction.text = "Got " + lootDropped + " loot!";
	}

	public void clearAction ()
	{
		shipAction.text = "";
	}

	 public void checkForTargets ()
	{
		if (isFiring == false) {
			InvokeRepeating ("fireLasers", 0.5f, fireRate);
			isFiring = true;
		}
	}

	public void stopAutoFire ()
	{
		CancelInvoke ("fireLasers");
		isFiring = false;
	}

	void fireLasers ()
	{
		GameObject autoLaser = Instantiate(autoProjectile, transform.position, Quaternion.identity) as GameObject;
		autoLaser.transform.SetParent(canvas.transform);
		autoLaser.GetComponent<AutoProjectile> ().shipStats = shipStats;
		autoLaser.GetComponent<Rigidbody2D>().velocity = new Vector3(0,autoLaserSpeed,0);
	}
}
