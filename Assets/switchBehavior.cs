using UnityEngine;
using System.Collections;

public class switchBehavior : MonoBehaviour {

	public GameObject[] switchObjects;
	bool eventTriggered;

	// Use this for initialization
	void Start () {

		eventTriggered = false;

		if (triggerBehavior.triggerSwitch == false) {
			
			(Instantiate (switchObjects[0], transform.position, transform.rotation) as GameObject).transform.parent = this.transform;
			
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
		if (eventTriggered == false && triggerBehavior.triggerSwitch == true) {

			destroyChild ();
			showHiddenTile ();

		}

	}

	void destroyChild () {
		
		foreach (Transform kid in this.transform) {
			//print ("kid: " + kid.name);
			Destroy (kid.gameObject);
		}
	}

	void showHiddenTile () {


		if (triggerBehavior.triggerSwitch == true) {

			Vector3 offsetPosition = new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z);
			
			(Instantiate (switchObjects[1], transform.position, transform.rotation) as GameObject).transform.parent = this.transform;
			(Instantiate (switchObjects[2], offsetPosition, transform.rotation) as GameObject).transform.parent = this.transform;

			eventTriggered = true;
			
		}
	
	
	}

}

