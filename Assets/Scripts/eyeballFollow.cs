using UnityEngine;
using System.Collections;

public class eyeballFollow : MonoBehaviour {

	public float lookRadius = 1; //Basically the size of the eyeball
	public float trackingSpeed = 1; //How fast the eyeball moves

	float elevation; //used to lock the eyeball into a plane, rather than moving in 3d space
	Vector3 targetPosition; //The target the eyeball is tracking
	Vector3 centerPos; // The center of the eyeball

	// Use this for initialization
	void Start () {

		centerPos = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

		eyeballTracking ();
	
	}

	//Track movement of another object while being confined to a radius
	void eyeballTracking () {

		elevation = transform.position.y;

		targetPosition = new Vector3(trackMe.playerPosX, elevation, trackMe.playerPosZ);
		Vector3 offset = targetPosition - centerPos;
		transform.position = centerPos + Vector3.ClampMagnitude(offset, lookRadius) * trackingSpeed * Time.deltaTime;

	}
}
