using UnityEngine;
using System.Collections;

public class wallColliderBehavior : MonoBehaviour {

	Vector3 rayDirection;
	bool iShouldntBeHere = false;

	// Use this for initialization
	void Start () {

		rayDirection = transform.TransformDirection(Vector3.up) * 1.0f;

		//comment this out to make the wall collider visible in game.
		renderer.enabled = false;
	
	}

	void Update () { 

		RaycastHit hit;

		if (Physics.Raycast(transform.position, rayDirection, out hit, 1.0f)) {
			
			iShouldntBeHere = hit.collider.CompareTag("Tile");
			
			if (iShouldntBeHere) {

				
				Debug.Log("I should not be here");
			}
		}
	}
	
	void OnTriggerEnter (Collider other) {

		var overLapping = other.GetComponent<baseTile>();

		if (overLapping) {

			print ("overlapping");
			Destroy(this.gameObject);
		}
	}
}
