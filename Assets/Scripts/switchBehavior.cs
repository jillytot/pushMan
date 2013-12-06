using UnityEngine;
using System.Collections;

public class switchBehavior : MonoBehaviour {

	public GameObject[] switchObjects; //objects that spawn on tile revealed by trigger.
	bool eventTriggered; //returns ture when the corresponding switch is hit

	// Use this for initialization
	void Start () {

		eventTriggered = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (eventTriggered == false && triggerBehavior.triggerSwitch == true) {

			destroyChild ();
			showHiddenTile ();
		}
	}

	void destroyChild () {

		//destroys child game object
		foreach (Transform kid in this.transform) {
			Destroy (kid.gameObject);
		}
	}

	void showHiddenTile () {

		//If the trigger has been switched on... disable my collider and spawn these objects in it's place.
		if (triggerBehavior.triggerSwitch == true) {

			Vector3 offsetPosition = new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z);

			gameObject.collider.enabled = false;
			(Instantiate (switchObjects[1], transform.position, transform.rotation) as GameObject).transform.parent = this.transform;
			(Instantiate (switchObjects[2], offsetPosition, transform.rotation) as GameObject).transform.parent = this.transform;

			eventTriggered = true;
		}
	}
}

