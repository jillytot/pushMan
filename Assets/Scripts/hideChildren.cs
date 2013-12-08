using UnityEngine;
using System.Collections;

public class hideChildren : MonoBehaviour {

	//These should correspond to the color of the switch they are associated with.   
	public bool greenEvent;
	public bool blueEvent;

	//For spawning particles:
	public GameObject revealEvent;

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
			child.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		//Depending on your color designation, do the corresponding action.
		//The collider needs to be disabled on any of these actions otherwise the children won't activate

		//Green Event
		if (greenEvent == true && greenTriggered == false && triggerBehavior.triggerGreen == true) {

			Instantiate(revealEvent, transform.position, transform.rotation); //particle effect
			gameObject.collider.enabled = false; //disable the collider
			activeAllChildren (); //activate all the children in the parent object
			Debug.Log ("Green Event is Happening");
			greenTriggered = true; //reports back this event is now triggered
		}

		//Blue Event
		if (blueEvent == true && blueTriggered == false && triggerBehavior.triggerBlue == true) {

			Instantiate(revealEvent, transform.position, transform.rotation);
			gameObject.collider.enabled = false;
			activeAllChildren ();
			Debug.Log ("Green Event is Happening");
			blueTriggered = true;
		}
	}

	void activeAllChildren () {

		Debug.Log ("Activate the Children!");

		foreach(Transform child in transform) 
			child.gameObject.SetActive(true);

	}
}
