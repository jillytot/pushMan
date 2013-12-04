using UnityEngine;
using System.Collections;

public class CameraFX : MonoBehaviour {

	public float currentHeight;
	public float followSpeed = 10;
	public float altitude;
	Vector3 targetPosition; //used for single value camera tracking
	Vector3 targetX; //used for rectRange camera tracking
	Vector3 targetZ; //used for rectRange camera tracking
	//bool moveCamera;
	public float cameraTollerance = 3; //If you move out of this range, the camera will follow you (linearRange)
	public float camRangeX = 8; //If you move out of horizontal range, the camera will follow you (rectRange)
	public float camRangeZ = 5; //If you move out of horizontal range, the camera will follow you (rectRange)

	void Awake () {

	}

	void LateUpdate () {

		//Only use one of these two functions for camera tracking. Currently rectRange is buggy, but it will be prefferred future method.

		//rectRange ();
		linearRange ();

	}

	//uses two values to control when the camera moves relative to the player's position on the screen
	void rectRange () {

		targetX = new Vector3(trackMe.playerPosX, altitude, currentHeight);
		targetZ = new Vector3(transform.position.x, altitude, trackMe.playerPosZ + currentHeight);
		targetPosition = new Vector3(trackMe.playerPosX, altitude, trackMe.playerPosZ + currentHeight);
		
		while (Vector3.Distance(transform.position, targetX) > camRangeX) {
			
			transform.position = Vector3.Slerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
		}
		
		while (Vector3.Distance(transform.position, targetZ) > camRangeZ) {
			
		transform.position = Vector3.Slerp(transform.position, targetZ, followSpeed * Time.deltaTime);

		}
	}

	//uses a single value for X and Z camera movement relative to the players position on the screen
	void linearRange () {

		targetPosition = new Vector3(trackMe.playerPosX, altitude, trackMe.playerPosZ + currentHeight);

		//print (targetPosition);
		
		while (Vector3.Distance(transform.position, targetPosition) > cameraTollerance) {
		
		transform.position = Vector3.Slerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
		}
	}
}
