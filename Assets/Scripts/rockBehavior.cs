using UnityEngine;
using System.Collections;

public class rockBehavior : MonoBehaviour {

	public enum treasure { //List of possible loot this rock can drop

		NONE,
		BLUEGEM,
		GREENGEM,
		REDGEM,
		PURPLEGEM,
		KEY,

	}

	public treasure myTreasure; //creating an instance of the enum for this rock to call

	public int rockHP = 3; //HP of rock
	public GameObject[] rockGraphics; //Different children which can spawn to show the state of the rock visually. 
	public GameObject[] treasureRockGraphics; //If the rock contains treasure, it's treated visually different.
	public GameObject[] myTreasures; //These gameobjects are tied directly to the Treasure Enum
	public GameObject sparks; // Effect for doing damage to the rock
	public float refreshTime = 0.1f; //currently keeps the spewtum bullet from doing extra damage.
	bool hitMeAgain; // Used to make sure damage is regulated
	bool containsTreasure; //Returns true if this rock contains treasure, and effects corresponding behavior.

	// Use this for initialization
	void Awake () { 

		//Let's determine if this rock contains treasure or not.
		if (myTreasure == treasure.NONE) {

			containsTreasure = false; 
			//Debug.Log ("I has no booty");
		} else {
			containsTreasure = true;
			//Debug.Log ("I has mad booty");
		}
	}

	void Start () {


		hitMeAgain = true;
		renderer.enabled = false; //toggle to make default rock object visible during gameplay.
		generateChild (); //This the starting graphic of the rock
	
	}
	
	//Controlls rules for taking damage
	void OnTriggerEnter (Collider other) {

		var imHit = other.GetComponent<Adventurer>();
		var spewHit = other.GetComponent<spewBulletBehavior>();

		//Do ths if i get hit with a pickaxe
		if (Adventurer.pickAxe == true && imHit) {
			rockHP -= 1;
			Instantiate(sparks,transform.position, transform.rotation);
			destroyChild ();
			generateChild ();
			//hitMeAgain = false;
			//StartCoroutine ("waitASec");
			
		}

		//Do this if i get hit with a Spewtum bullet
		if (hitMeAgain == true && spewHit) {

			rockHP -= 1;
			Instantiate(sparks,transform.position, transform.rotation);
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

		//If i have no treasure, generate these graphics.
		if (containsTreasure == false) {
		
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

		//If i have treasure, generate these graphics, and also drop the treasure.
		if (containsTreasure == true) {

			switch(rockHP) {
			case 3:
				(Instantiate (treasureRockGraphics[2], transform.position, transform.rotation) as GameObject).transform.parent = this.transform;
				break;
			case 2:
				(Instantiate (treasureRockGraphics[1], transform.position, transform.rotation) as GameObject).transform.parent = this.transform;
				break;
			case 1:
				(Instantiate (treasureRockGraphics[0], transform.position, transform.rotation) as GameObject).transform.parent = this.transform;
				treasureGenerator ();
				break;
			default:
				Destroy(this.gameObject);
				break;
			}
		}
	}

	//causes a small time delay before the rock can get hit again, and keeps certain collisions from counting twice.
	IEnumerator waitASec () {

		yield return new WaitForSeconds(refreshTime);
		hitMeAgain = true;
	}

	//Generates a treasure depending on the assigned enum, pulling from the list of myTreasures[] gameobjects.
	public void treasureGenerator () {

		switch (myTreasure) {
			
		case treasure.BLUEGEM:
			Instantiate(myTreasures[0],transform.position, transform.rotation);
			break;
		case treasure.GREENGEM:
			Instantiate(myTreasures[1],transform.position, transform.rotation);
			break;
		case treasure.REDGEM:
			Instantiate(myTreasures[2],transform.position, transform.rotation);
			break;
		case treasure.PURPLEGEM:
			Instantiate(myTreasures[3],transform.position, transform.rotation);
			break;
		case treasure.KEY:
			Instantiate(myTreasures[4],transform.position, transform.rotation);
			break;
		default:
			break;
		}
	}
}
