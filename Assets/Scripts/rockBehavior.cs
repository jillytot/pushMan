using UnityEngine;
using System.Collections;

public class rockBehavior : MonoBehaviour {

	public int rockHP = 3; //HP of rock
	public GameObject[] rockGraphics; //Different children which can spawn to show the state of the rock visually. 
	public GameObject sparks;
	public float refreshTime = 0.1f;
	bool hitMeAgain;

	// Use this for initialization
	void Start () {

		hitMeAgain = true;
		renderer.enabled = false; //toggle to make default rock object visible during gameplay.
		generateChild ();
	
	}
	
	//Controlls rules for taking damage
	void OnTriggerEnter (Collider other) {

		var imHit = other.GetComponent<Adventurer>();
		var spewHit = other.GetComponent<spewBulletBehavior>();

		if (Adventurer.pickAxe == true && imHit) {
			rockHP -= 1;
			GameObject spawnSparks = (GameObject)Instantiate(sparks,transform.position, transform.rotation);
			destroyChild ();
			generateChild ();
			//hitMeAgain = false;
			//StartCoroutine ("waitASec");
			
		}

		if (hitMeAgain == true && spewHit) {

			rockHP -= 1;
			GameObject spawnSparks = (GameObject)Instantiate(sparks,transform.position, transform.rotation);
			destroyChild ();
			generateChild ();
			hitMeAgain = false;
			StartCoroutine ("waitASec");

		}
	}

	//destroys current rock graphic to be replaced by a new one.
	void destroyChild () {
		
		foreach (Transform kid in this.transform) {
			//print ("kid: " + kid.name);
			Destroy (kid.gameObject);
		}
	}

	//Genrates new graphics based on rockHP
	void generateChild () {
		switch(rockHP) {
		case 3:
			(Instantiate (rockGraphics[2], transform.position, transform.rotation) as GameObject).transform.parent = this.transform;
			break;
		case 2:
			(Instantiate (rockGraphics[1], transform.position, transform.rotation) as GameObject).transform.parent = this.transform;
			break;
		case 1:
			(Instantiate (rockGraphics[0], transform.position, transform.rotation) as GameObject).transform.parent = this.transform;
			break;
		default:
			Destroy(this.gameObject);
			break;
		}
	}

	IEnumerator waitASec () {

		yield return new WaitForSeconds(refreshTime);
		hitMeAgain = true;
	}
}
