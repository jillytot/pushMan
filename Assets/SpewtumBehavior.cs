using UnityEngine;
using System.Collections;

public class SpewtumBehavior : MonoBehaviour {

	public float spewRange = 12;
	public float spewSpeed = 1;
	public float reloadTime = 1;
	public GameObject spew;
	public GameObject spewNoise;

	public Quaternion facingDIrection = Quaternion.identity;

	Vector3 north;
	Vector3 east;
	Vector3 south;
	Vector3 west;

	bool spewLoaded = true;
	bool startReloading = false;
	bool fireNorth = false;
	bool fireSouth = false;
	bool fireEast = false;
	bool fireWest = false;
	
	// Use this for initialization
	void Start () {

		north = transform.TransformDirection(Vector3.forward) * spewRange;
		east = transform.TransformDirection(Vector3.right) * spewRange;
		south = transform.TransformDirection(Vector3.back) * spewRange;
		west = transform.TransformDirection(Vector3.left) * spewRange;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		showRaycasts ();
		detectTarget ();
		spewChunk ();

		if (startReloading == true) {

			StartCoroutine("reload");

		}

	}

	void detectTarget () {


		RaycastHit hit;

		//if (Physics.Raycast(transform.position, north, out hit , spewRange)) {

		if (Physics.Raycast(transform.position, north, out hit, spewRange)) {

			fireNorth = hit.collider.CompareTag("Player");

			if (fireNorth) {
				
				Debug.Log("target is North");
			}
		}

		if (Physics.Raycast(transform.position, south, out hit, spewRange)) {
			
			fireSouth = hit.collider.CompareTag("Player");
			
			if (fireSouth) {
				
				Debug.Log("target is South");
			}
		}

		if (Physics.Raycast(transform.position, east, out hit, spewRange)) {
			
			fireEast = hit.collider.CompareTag("Player");
			
			if (fireEast) {
				
				Debug.Log("target is East");
			}
		}

		if (Physics.Raycast(transform.position, west, out hit, spewRange)) {
			
			fireWest = hit.collider.CompareTag("Player");
			
			if (fireWest) {
				
				Debug.Log("target is West");
			}
		}
	}

	void spewChunk () {

		var faceSouth = Quaternion.LookRotation(south);
		var faceWest = Quaternion.LookRotation(west);
		var faceEast = Quaternion.LookRotation(east);

		if (fireNorth && spewLoaded) {

			GameObject spewNorth = (GameObject)Instantiate(spew, transform.position, transform.rotation);
			GameObject spewAudio = (GameObject)Instantiate(spewNoise, transform.position, transform.rotation);

			Debug.Log ("Fire");
			spewLoaded = false;
			startReloading = true;
			fireNorth = false;
		}

		if (fireSouth && spewLoaded) {
			
			GameObject spewSouth = (GameObject)Instantiate(spew, transform.position, faceSouth);
			GameObject spewAudio = (GameObject)Instantiate(spewNoise, transform.position, transform.rotation);
			
			Debug.Log ("Fire");
			spewLoaded = false;
			startReloading = true;
			fireSouth = false;
		}

		if (fireWest && spewLoaded) {
			
			GameObject spewWest = (GameObject)Instantiate(spew, transform.position, faceWest);
			GameObject spewAudio = (GameObject)Instantiate(spewNoise, transform.position, transform.rotation);
			
			Debug.Log ("Fire");
			spewLoaded = false;
			startReloading = true;
			fireWest = false;
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

	IEnumerator reload () {

		startReloading = false;
		Debug.Log ("Loading Spew in " + reloadTime + " seconds");
		yield return new WaitForSeconds (reloadTime);
		spewLoaded = true;
		Debug.Log("Spew Loaded");

	}

	void showRaycasts () {

		//show raycasts
		Debug.DrawRay(transform.position, east, Color.red, spewRange);
		Debug.DrawRay(transform.position, west, Color.blue, spewRange);
		Debug.DrawRay(transform.position, north, Color.green, spewRange);
		Debug.DrawRay(transform.position, south, Color.yellow, spewRange);
		
	}
}
