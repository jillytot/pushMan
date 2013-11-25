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
		
		/*Debug.DrawRay (transform.position, Vector3.forward,Color.blue,1000);

		RaycastHit hit;
		if (Physics.Raycast(transform.position, Vector3.forward, out hit , tileSize)) {
			Debug.Log("There is something in front of me");
			Debug.Log (hit.collider.tag);

			itsLocked = hit.collider.CompareTag("Locked");

			if (itsLocked) {
				Debug.Log ("It's Locked...");
			}
		} 
		 */
		
		//Pushman Can Jump?
		//if(Input.GetButtonDown("Jump")) {
			//rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
		//}
	}
	

	void OnTriggerEnter (Collider other) {
		var gem = other.GetComponent<Gem> ();
		var key = other.GetComponent<keyScript> ();
		var itsLocked = other.GetComponent<lockBehavior>();
		var getTool = other.GetComponent<itemTool>();

		//Collect Gems
		if (gem) {
			gemCount += gem.gemValue;
			Destroy (gem.gameObject);
		}
		//get keys
			if (key) {
				keyCount += key.keyType;
				Destroy (key.gameObject);
		}
		if (itsLocked && keyCount > 0) {
			keyCount -= 1;
			Destroy (itsLocked.gameObject);
		}
		if (getTool) {
			pickAxe = true;
			Destroy (getTool.gameObject);
		}
	}

	//Behavior for Pickaxe,
	//When colliding with a rock object w/ pickaxe equipped, decrement HP from the rock, if the rock reaches 0 HP, then destroy the rock
	void usePickAxe () {
	
	}
}