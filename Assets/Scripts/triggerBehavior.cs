using UnityEngine;
using System.Collections;

public class triggerBehavior : MonoBehaviour {

	//To do: Multiple switches which reveal different tiles

	public bool switchGreen;
	public bool switchBlue;

	public static bool triggerSwitch; //this value is changed by the player via collision.
	public static bool triggerBlue;
	public static bool triggerGreen;

	public AudioClip switchSFX;
	//public static triggerBehavior triggerInst;

	// Use this for initialization
	void Start () {

		triggerBlue = false;
		triggerGreen = false;
		triggerSwitch = false;
	
	}

	void OnTriggerEnter (Collider other) {

		var triggered = other.GetComponent<Adventurer>();

		if (triggered == true && switchGreen == true && triggerGreen == false) {

			audio.PlayOneShot(switchSFX, 0.5F);
		    Debug.Log("You hit a green switch");
			triggerGreen = true;

		}

		if (triggered == true && switchBlue == true && triggerBlue == false) {

			audio.PlayOneShot(switchSFX, 0.5F);
			Debug.Log("You hit a blue switch");
			triggerBlue = true;
			
		}
	}
}
