using UnityEngine;
using System.Collections;

public class hideChildren : MonoBehaviour {

	//These should correspond to the color of the switch they are associated with.
	public bool greenEvent;
	public bool blueEvent;

	//These are used to trigger specific behavior depending on which color switch it's tied to. 
	bool greenTriggered;
	bool blueTriggered;

	// Use this for initialization
	void Start () {

		//initialize this conditionals as false so their corresponding events are only triggered once in update
		greenTriggered = false;
		blueTriggered = false;

		//deactivate all the children in this object until an event is triggered.
		foreach(Transform child in transform) 
			child.gameObject.active = !child.gameObject.active;
	}
	
	// Update is called once per frame
	void Update () {

		//Depending on your color designation, do the corresponding action. 
		//The collider needs to be disabled on any of these actions otherwise the children won't activate

		//Green Event
		if (greenEvent == true && greenTriggered == false && triggerBehavior.triggerGreen == true) {

			gameObject.collider.enabled = false;
			activeAllChildren ();
			Debug.Log ("Green Event is Happening");
			greenTriggered = true;
		}

		//Blue Event
		if (blueEvent == true && blueTriggered == false && triggerBehavior.triggerBlue == true) {
			
			gameObject.collider.enabled = false;
			activeAllChildren ();
			Debug.Log ("Green Event is Happening");
			blueTriggered = true;
		}
	}

	void activeAllChildren () {

		Debug.Log ("Activate the Children!");

		foreach(Transform child in transform) 
			child.gameObject.active = true;

	}
}
