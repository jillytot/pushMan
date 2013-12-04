using UnityEngine;
using System.Collections;

//this is used for smoothing the rotation of the character as it turns
public static class CustomExtensions {
	public static Quaternion EaseTowards(this Quaternion curr, Quaternion target, float easing) {
	return Quaternion.Slerp(curr, target, Mathf.Pow(easing, Mathf.Clamp01(60f * Time.deltaTime)));
	}
}

[RequireComponent(typeof(Rigidbody))]
public class Adventurer : MonoBehaviour {

	//gameplay variables
	public static int gemCount = 0; //How many total gems do i have? 
	public static int keyCount = 0; // How many total keys am i carrying?
	public static bool pickAxe; //Do i have a pickaxe?

	//audio clips
	public AudioClip getItemSFX; // sound for getting an item
	public AudioClip getGemSFX; // sound for getting a gem
	public AudioClip unlockDoorSFX; // sound for unlocking a door

	//other variables
    public float moveSpeed = 10f; //How fast does pushman Move?
    public float turnSpeed = 0.2f; //How fast do i turn?
	Rigidbody body; //an instance of the rigid body that can be acted upon (I think...)
	bool grounded = false; //Returns true if player is over an object (might use in the future for jumping)
	float tileSize = 2; //tile size is used for physics calculations
	public static float playerPosX; //used for camera tracking
	public static float playerPosZ; //used for camera tracking
	public static Adventurer thisPlayer; //Create a static instance of the player to make accessing its variables easier..

	void Awake() {
		thisPlayer = this; //icreates the static instance of this player
		body = GetComponent<Rigidbody>(); //creates rigidbody instance

		//Consider moving this to a new code snippet so it does not interffer with future mechanics...
		playerPosX = transform.position.x; //easily allows the player's position to be tracked. (currently by the CameraFX.cs)
		//print (playerPosX);
		playerPosZ = transform.position.z; //easily allows the players position to be tracked (currently by the CameraFX.cs)
		//print (playerPosZ);
	}

	void Start () {

		pickAxe = false; //always start a level with no pickaxe

	}
    
    // Basic Controls: Pushman goes up, down, left, and right,
	// Pushman also rotates towards the position he is travelling.
	
    void Update () {

		//Let's update our position so we can be tracked by the camera.
		playerPosX = transform.position.x; 
		//print (playerPosX);
		playerPosZ = transform.position.z;
		//print (playerPosZ);

		//Creates movement in x and z directions.
		var inputSignal = new Vector3(
			Input.GetAxisRaw("Horizontal"),
			0,
			Input.GetAxisRaw("Vertical")
		);
		if (inputSignal.sqrMagnitude > 0.05f * 0.05f) {
			body.MovePosition(body.position + (moveSpeed * Time.deltaTime) * inputSignal); //move in direction of input
			var targetRotation = Quaternion.LookRotation(inputSignal);
			body.MoveRotation( body.rotation.EaseTowards(targetRotation, turnSpeed) ); //rotate and face direction of input
		}

		// Detect Platform, probably no longer needed...
		Vector3 onPlatform = transform.InverseTransformDirection(Vector3.down);
		if (Physics.Raycast(transform.position, onPlatform, 10))
			//print ("There is something below me");
			grounded = true;
	}
	
	//Manages different collisions
	void OnTriggerEnter (Collider other) {
		var gem = other.GetComponent<Gem> (); //I hit a gem
		var key = other.GetComponent<keyScript> (); //I hit a key
		var itsLocked = other.GetComponent<lockBehavior>(); //I hit a locked door
		var getTool = other.GetComponent<itemTool>(); //I found a tool
		var goToNextLevel = other.GetComponent<starBehavior>(); //I reached the end of the level
		var hitSwitch = other.GetComponent<triggerBehavior>(); //I hit a switch

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
		//If i have a key, use it and unlock the door 
		if (itsLocked && keyCount > 0) {
			audio.PlayOneShot(unlockDoorSFX, 0.4F);
			keyCount -= 1;
			Destroy (itsLocked.gameObject);
		}
		//sets pickaxe to true on collision
		if (getTool) {
			audio.PlayOneShot(getItemSFX, 0.5F);
			pickAxe = true;
			Destroy (getTool.gameObject);
		}
		//loads next level on colliision
		if (goToNextLevel) {
			Application.LoadLevel(Application.loadedLevel+1);
		}
		//activate a switch on collision
		if (hitSwitch && triggerBehavior.triggerSwitch == false) {
			triggerBehavior.triggerSwitch = true;
			audio.PlayOneShot(getItemSFX, 0.5F);
		}
	}
}