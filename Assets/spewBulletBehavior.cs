using UnityEngine;
using System.Collections;

public class spewBulletBehavior : MonoBehaviour {

	public GameObject makeExplosion;

	void Start () {

		//Physics.IgnoreCollision(gameObject.GetComponent, collider);

	}

	//Make the rock hit things and die.
	void OnTriggerEnter (Collider other) {
		
		var iHitARock = other.GetComponent<rockBehavior>();
		var iHitALooker = other.GetComponent<lookerBehavior>();
		var iHitPlayer = other.GetComponent<Adventurer>();
		
		if (iHitARock || iHitPlayer) {

		
			destroyMe ();
			
		}

		if (iHitALooker) {
			
			Destroy (iHitALooker.gameObject);
			destroyMe ();
			
		}
	}

	void destroyMe () {

		Debug.Log ("I hit a rock");
		Instantiate(makeExplosion, transform.position, transform.rotation);
		Destroy(this.gameObject);
		
	}
}
