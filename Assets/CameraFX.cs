using UnityEngine;
using System.Collections;

public class CameraFX : MonoBehaviour {
	
	public GameObject target;
	public float currentHeight;
	public float followSpeed = 1;
	public float altitude;
	Vector3 targetPosition;
	Vector3 offset;
	Vector3 origin;
	bool moveCamera;
	public float cameraTollerance = 3;

	void Awake () {

		//currentHeight = transform.position.z;
		//altitude = transform.position.y;
		//targetPosition = new Vector3(Adventurer.playerPosX, transform.position.y, Adventurer.playerPosZ - 35);


	}

	void LateUpdate () {

		targetPosition = new Vector3(Adventurer.playerPosX, altitude, Adventurer.playerPosZ + currentHeight);


		while (Vector3.Distance(transform.position, targetPosition) > cameraTollerance) {

		transform.position = Vector3.Slerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
		}
	}
}
