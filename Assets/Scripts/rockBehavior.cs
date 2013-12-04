using UnityEngine;
using System.Collections;

public class rockBehavior : MonoBehaviour {

	public int rockHP = 3; //HP of rock
	bool killChild; //Used to generate new image depending on HP or rock.
	public GameObject[] rockGraphics; //Different children which can spawn to show the state of the rock visually. 
	public GameObject sparks;
	//public AudioClip breakRock;

	// Use this for initialization
	void Start () {

		renderer.enabled = false; //toggle to make default rock object visible during gameplay.
		killChild = false;
		generateChild ();
	
	}
	
	// Update is called once per frame
	void Update () {

	//	if (rockHP < 1) {

			//Destroy(this.gameObject);
		//}
	
	}

	void destroyChild () {

	foreach (Transform kid in this.transform) {
			//print ("kid: " + kid.name);
			Destroy (kid.gameObject);
		}
	}

	//Controlls rules for taking damage
	void OnTriggerEnter (Collider other) {

		var imHit = other.GetComponent<Adventurer>();

		if (Adventurer.pickAxe == true) {
			//audio.PlayOneShot(breakRock, 0.7F);
			rockHP -= 1;
			GameObject spawnSparks = (GameObject)Instantiate(sparks,transform.position, transform.rotation);
			destroyChild ();
			generateChild ();

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

}
