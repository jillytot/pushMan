using UnityEngine;
using System.Collections;

public class SpewtumBehavior : MonoBehaviour {

	public float spewRange = 12; // How far can Spewtum shoot?
	public float spewSpeed = 1; //How fast does the bullet fly?
	public float reloadTime = 1; //How long until he can fire again?
	public GameObject spew; // Used to instantiate Spewtum's projectile
	public GameObject spewNoise; //used to create Spewtum's sound

	public Quaternion facingDIrection = Quaternion.identity; //used for determining the rotation of the projectile's spawn.

	//short cuts for directions
	Vector3 north;
	Vector3 east;
	Vector3 south;
	Vector3 west;

	//Conditionals used for firing projectiles.
	bool spewLoaded = true;
	bool startReloading = false;
	bool fireNorth = false;
	bool fireSouth = false;
	bool fireEast = false;
	bool fireWest = false;
	
	// Use this for initialization
	void Start () {

		//Let's define those directions.
		north = transform.TransformDirection(Vector3.forward) * spewRange;
		east = transform.TransformDirection(Vector3.right) * spewRange;
		south = transform.TransformDirection(Vector3.back) * spewRange;
		west = transform.TransformDirection(Vector3.left) * spewRange;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//After firing a bullet, you need to load
		if (startReloading == true) {

			StartCoroutine("reload");

		}

		//Call these funtions on Update
		//showRaycasts ();
		detectTarget ();

	}

	//rules for detecting if the player is in firing range and how to fire at them.
	void detectTarget () {

		//Determine which direction to shoot the bullet in
		var faceSouth = Quaternion.LookRotation(south);
		var faceWest = Quaternion.LookRotation(west);
		var faceEast = Quaternion.LookRotation(east);

		//Use the hit to determine what course of action to take.
		RaycastHit hit;

		//If the raycast hits the player, tell Spewtum to fire in that direction.
		//Do this for all 4 directions.

		//Then if there is a target and bullet is loaded:

		//If Spewtum is ready to fire, use the direction received from detectTarget to spawn a bullet facing that direction.
		//Spewtum also plays a sound spawned as a separate object so the sound won't get destroyed on level load. 

		if (Physics.Raycast(transform.position, north, out hit, spewRange)) {

			fireNorth = hit.collider.CompareTag("Player");

			if (fireNorth) {
				
				Debug.Log("target is North");
			}

			if (fireNorth && spewLoaded) {
				
				GameObject spewNorth = (GameObject)Instantiate(spew, transform.position, transform.rotation);
				GameObject spewAudio = (GameObject)Instantiate(spewNoise, transform.position, transform.rotation);
				
				Debug.Log ("Fire");
				spewLoaded = false;
				startReloading = true;
				fireNorth = false;
			}
		}

		if (Physics.Raycast(transform.position, south, out hit, spewRange)) {
			
			fireSouth = hit.collider.CompareTag("Player");
			
			if (fireSouth) {
				
				Debug.Log("target is South");
			}

			if (fireSouth && spewLoaded) {
				
				GameObject spewSouth = (GameObject)Instantiate(spew, transform.position, faceSouth);
				GameObject spewAudio = (GameObject)Instantiate(spewNoise, transform.position, transform.rotation);
				
				Debug.Log ("Fire");
				spewLoaded = false;
				startReloading = true;
				fireSouth = false;
			}
		}

		if (Physics.Raycast(transform.position, east, out hit, spewRange)) {
			
			fireEast = hit.collider.CompareTag("Player");
			
			if (fireEast) {
				
				Debug.Log("target is East");
			}

			if (fireEast && spewLoaded) {
				
				GameObject spewEast = (GameObject)Instantiate(spew, transform.position, faceEast);
				GameObject spewAudio = (GameObject)Instantiate(spewNoise, transform.position, transform.rotation);
				
				Debug.Log ("Fire");
				spewLoaded = false;
				startReloading = true;
				fireEast = false;
			}
		}

		if (Physics.Raycast(transform.position, west, out hit, spewRange)) {
			
			fireWest = hit.collider.CompareTag("Player");
			
			if (fireWest) {
				
				Debug.Log("target is West");
			}

			if (fireWest && spewLoaded) {
				
				GameObject spewWest = (GameObject)Instantiate(spew, transform.position, faceWest);
				GameObject spewAudio = (GameObject)Instantiate(spewNoise, transform.position, transform.rotation);
				
				Debug.Log ("Fire");
				spewLoaded = false;
				startReloading = true;
				fireWest = false;

			}
		}
	}


	//Once fired, wait a certain amount of time before being able to fire again.
	IEnumerator reload () {

		startReloading = false;
		Debug.Log ("Loading Spew in " + reloadTime + " seconds");
		yield return new WaitForSeconds (reloadTime);

		Debug.Log("Spew Loaded");
		yield return new WaitForFixedUpdate ();
		spewLoaded = true;

	}

	//Call this function to show Spewtums Raycasts
	void showRaycasts () {

		//show raycasts
		Debug.DrawRay(transform.position, east, Color.red, spewRange);
		Debug.DrawRay(transform.position, west, Color.blue, spewRange);
		Debug.DrawRay(transform.position, north, Color.green, spewRange);
		Debug.DrawRay(transform.position, south, Color.yellow, spewRange);
		
	}
}
