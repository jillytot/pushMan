using UnityEngine;
using System.Collections;

public class triggerBehavior : MonoBehaviour {

	//To do: Multiple switches which reveal different tiles

	//What color switch is this?
	public bool switchGreen;
	public bool switchBlue;

	public static bool triggerSwitch; //this value is changed by the player via collision.

	//These return true on collsion with player depending on the color of the switch
	public static bool triggerBlue;
	public static bool triggerGreen;

	//For playing a sound when the switch is triggered.
	public AudioClip switchSFX;

	// Use this for initialization
	void Start () {

		//intialize these values as false
		triggerBlue = false;
		triggerGreen = false;
		triggerSwitch = false;
	
	}

	void OnTriggerEnter (Collider other) {

		//determines whether you've collided with the player
		var triggered = other.GetComponent<Adventurer>();

		//Depending on your color when triggered, do these things

		//Green Switch
		if (triggered == true && switchGreen == true && triggerGreen == false) {

			audio.PlayOneShot(switchSFX, 0.5F);
		    Debug.Log("You hit a green switch");
			triggerGreen = true;

		}

		//Blue Switch
		if (triggered == true && switchBlue == true && triggerBlue == false) {

			audio.PlayOneShot(switchSFX, 0.5F);
			Debug.Log("You hit a blue switch");
			triggerBlue = true;
			
		}
	}
}
