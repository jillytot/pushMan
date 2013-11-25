using UnityEngine;
using System.Collections;

public class rockBehavior : MonoBehaviour {

	public int rockHP = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (rockHP < 1) {

			Destroy(this.gameObject);
		}
	
	}

	void OnTriggerEnter (Collider other) {

		var imHit = other.GetComponent<Adventurer>();

		if (Adventurer.pickAxe == true) {
			rockHP -= 1;
		}
	}
}
