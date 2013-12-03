using UnityEngine;
using System.Collections;

public static class CustomExtensions {
	public static Quaternion EaseTowards(this Quaternion curr, Quaternion target, float easing) {
	return Quaternion.Slerp(curr, target, Mathf.Pow(easing, Mathf.Clamp01(60f * Time.deltaTime)));
	}
}

[RequireComponent(typeof(Rigidbody))]
public class Adventurer : MonoBehaviour {
	
    public float moveSpeed = 10f;
    public float turnSpeed = 0.2f;
	Rigidbody body;
	public static int gemCount = 0;
	public static int keyCount = 0;
	bool grounded = false;
	float tileSize = 2;
	public static bool pickAxe;
	public AudioClip getItemSFX;
	public AudioClip getGemSFX;
	public AudioClip unlockDoorSFX;

	void Awake() {
		body = GetComponent<Rigidbody>();
	}

	void Start () {
		pickAxe = false;
	}
    
    // Basic Controls: Pushman goes up, down, left, and right,
	// Pushman also rotates towards the position he is travelling.
	
    void Update () {
		var inputSignal = new Vector3(
			Input.GetAxisRaw("Horizontal"),
			0,
			Input.GetAxisRaw("Vertical")
		);
		if (inputSignal.sqrMagnitude > 0.05f * 0.05f) {
			body.MovePosition(body.position + (moveSpeed * Time.deltaTime) * inputSignal);
			var targetRotation = Quaternion.LookRotation(inputSignal);
			body.MoveRotation( body.rotation.EaseTowards(targetRotation, turnSpeed) );
		}

		// Detect Platform
		Vector3 onPlatform = transform.InverseTransformDirection(Vector3.down);
		if (Physics.Raycast(transform.position, onPlatform, 10))
			//print ("There is something below me");
			grounded = true;
	}
	
	//Manages different collisions
	void OnTriggerEnter (Collider other) {
		var gem = other.GetComponent<Gem> ();
		var key = other.GetComponent<keyScript> ();
		var itsLocked = other.GetComponent<lockBehavior>();
		var getTool = other.GetComponent<itemTool>();
		var goToNextLevel = other.GetComponent<starBehavior>();

		//Collect Gems
		if (gem) {
			audio.PlayOneShot(getGemSFX, 2.0f);
			gemCount += gem.gemValue;
			Destroy (gem.gameObject);
		}
		//get keys
			if (key) {
				audio.PlayOneShot(getItemSFX, 0.7F);
				keyCount += key.keyType;
				Destroy (key.gameObject);
		}
		if (itsLocked && keyCount > 0) {
			audio.PlayOneShot(unlockDoorSFX, 0.4F);
			keyCount -= 1;
			Destroy (itsLocked.gameObject);
		}
		if (getTool) {
			audio.PlayOneShot(getItemSFX, 0.5F);
			pickAxe = true;
			Destroy (getTool.gameObject);
		}
		if (goToNextLevel) {
			Application.LoadLevel("testScene2");
		}
	}

	//Behavior for Pickaxe,
	//When colliding with a rock object w/ pickaxe equipped, decrement HP from the rock, if the rock reaches 0 HP, then destroy the rock
	void usePickAxe () {
	
	}
}