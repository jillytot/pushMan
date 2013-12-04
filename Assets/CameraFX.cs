using UnityEngine;
using System.Collections;

public class CameraFX : MonoBehaviour {

	public float currentHeight;
	public float followSpeed = 10;
	public float altitude;
	Vector3 targetPosition;
	Vector3 targetX;
	Vector3 targetZ;
	bool moveCamera;
	public float cameraTollerance = 3;
	public float camRangeX = 8;
	public float camRangeZ = 5;

	void Awake () {

	}

	void LateUpdate () {

		//rectRange ();
		linearRange ();

	}

	//uses two values to control when the camera moves relative to the player's position on the screen
	void rectRange () {

		targetX = new Vector3(Adventurer.playerPosX, altitude, currentHeight);
		targetZ = new Vector3(transform.position.x, altitude, Adventurer.playerPosZ + currentHeight);
		targetPosition = new Vector3(Adventurer.playerPosX, altitude, Adventurer.playerPosZ + currentHeight);
		
		while (Vector3.Distance(transform.position, targetX) > camRangeX) {
			
			transform.position = Vector3.Slerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
		}
		
		while (Vector3.Distance(transform.position, targetZ) > camRangeZ) {
			
		transform.position = Vector3.Slerp(transform.position, targetZ, followSpeed * Time.deltaTime);

		}
	}

	//uses a single value for X and Z camera movement relative to the players position on the screen
	void linearRange () {

		targetPosition = new Vector3(Adventurer.playerPosX, altitude, Adventurer.playerPosZ + currentHeight);
		
		while (Vector3.Distance(transform.position, targetPosition) > cameraTollerance) {
		
		transform.position = Vector3.Slerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
		}
	}
}
