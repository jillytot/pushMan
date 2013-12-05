using UnityEngine;
using System.Collections;

public class wallColliderBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//comment this out to make the wall collider visible in game.
		renderer.enabled = false;
	
	}
	
	void OnTriggerEnter (Collider other) {

		var overLapping = other.GetComponent<baseTile>();

		if (overLapping) {

			print ("overlapping");
			Destroy(this.gameObject);
		}
	}
}
