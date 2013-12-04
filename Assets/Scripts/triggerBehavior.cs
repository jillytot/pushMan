using UnityEngine;
using System.Collections;

public class triggerBehavior : MonoBehaviour {

	//To do: Multiple switches which reveal different tiles

	public static bool triggerSwitch; //this value is changed by the player via collision.
	//public static triggerBehavior triggerInst;

	// Use this for initialization
	void Start () {

		triggerSwitch = false;
	
	}
}
