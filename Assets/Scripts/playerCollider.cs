using UnityEngine;
using System.Collections;

public class playerCollider : MonoBehaviour {

	public GameObject sparks;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

/*	void OnTriggerEnter (Collider other) {
		
		var rockHit = other.GetComponent<rockBehavior>();
		
		if (Adventurer.pickAxe == true) {

			GameObject spawnSparks = (GameObject)Instantiate(sparks,transform.position, transform.rotation);

			
		}
	} */
}
