using UnityEngine;
using System.Collections;

public class LerpMe : MonoBehaviour {

	public float speed = 1;
	public float riseDistance = 1;
	Vector3 myPos;

	// Use this for initialization
	void Start () {
	
		myPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		var driftUp = new Vector3(myPos.x, myPos.y + riseDistance, myPos.z);
		transform.position = Vector3.Lerp(transform.position, driftUp, speed  * Time.deltaTime);
	
	}
}
