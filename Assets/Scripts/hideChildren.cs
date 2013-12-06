using UnityEngine;
using System.Collections;

public class hideChildren : MonoBehaviour {

	public bool greenEvent;
	public bool blueEvent;

	bool eventTriggered;
	bool greenTriggered;
	bool blueTriggered;

	// Use this for initialization
	void Start () {

		//First disable the children at game start
		eventTriggered = false;
		greenTriggered = false;
		blueTriggered = false;

		foreach(Transform child in transform) 
			child.gameObject.active = !child.gameObject.active;
	}
	
	// Update is called once per frame
	void Update () {

		//Then when an event is triggered, activate all the children.
		if (eventTriggered == false && triggerBehavior.triggerSwitch == true) {

			//If you don't disable the collider, the children will not spawn, nor will the player be able to pass through the space. 
			gameObject.collider.enabled = false;
			deactiveAllChildren ();
			eventTriggered = true;

		}

		if (greenEvent == true && greenTriggered == false && triggerBehavior.triggerGreen == true) {

			gameObject.collider.enabled = false;
			deactiveAllChildren ();
			Debug.Log ("Green Event is Happening");
			greenTriggered = true;
		}

		if (blueEvent == true && blueTriggered == false && triggerBehavior.triggerBlue == true) {
			
			gameObject.collider.enabled = false;
			deactiveAllChildren ();
			Debug.Log ("Green Event is Happening");
			blueTriggered = true;
		}
	}

	void deactiveAllChildren () {

		Debug.Log ("Activate the Children!");

		foreach(Transform child in transform) 
			child.gameObject.active = true;

	}
}
