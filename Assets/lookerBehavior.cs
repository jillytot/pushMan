using UnityEngine;
using System.Collections;



public class lookerBehavior : MonoBehaviour {

	float tileSize = 2;

	Vector3 forward;
	Vector3 right;
	Vector3 back;
	Vector3 left;

	//public enum Direction { Forward, Back, Left, Right}
	//public Direction direction;

	// Use this for initialization
	void Start () {

		forward = transform.TransformDirection(Vector3.forward) * tileSize;
		right = transform.TransformDirection(Vector3.right) * tileSize;
		back = transform.TransformDirection(Vector3.back) * tileSize;
		left = transform.TransformDirection(Vector3.left) * tileSize;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		availableDIrections ();
	
	}

	void availableDIrections () {

		RaycastHit hit;

		if (Physics.Raycast(transform.position, forward, out hit , tileSize)) {

			Debug.Log("There is something in font of me");
		}

		if (Physics.Raycast(transform.position, right, out hit , tileSize)) {
			
			Debug.Log("There is something to my right");
		}

		if (Physics.Raycast(transform.position, back, out hit , tileSize)) {
			
			Debug.Log(" behind me");
		}

		if (Physics.Raycast(transform.position, left, out hit , tileSize)) {
			
			Debug.Log("There is something to my left");
		}
	}
}
