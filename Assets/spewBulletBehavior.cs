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
		var iHitPlayer = other.GetComponent<Adventurer>();
		
		if (iHitARock || iHitPlayer) {

			destroyMe ();
			
		}
	}

	void destroyMe () {

		Debug.Log ("I hit a rock");
		GameObject explode = (GameObject)Instantiate(makeExplosion, transform.position, transform.rotation);
		Destroy(this.gameObject);
		
	}
}
