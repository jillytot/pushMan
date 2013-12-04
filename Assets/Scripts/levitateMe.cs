using UnityEngine;
using System.Collections;

public class levitateMe : MonoBehaviour {
	
	Vector3 origin; //starting position of object
	Vector3 target; //disired position
	public float levRange= 1.0f; //the distance the objeject will move as it levitates
	public float levSpeed = 1.0f; //the speed at which the object moves between its origin and target positions
	bool nextHover; //triggers movement up or down

	void Start () {

		//initialized variables at start...
		origin = transform.position;
		//print(origin.y);
		target = new Vector3(origin.x, origin.y + levRange, origin.z);
		nextHover = true;
	
		}

	void Update () {

		//Makes object move up
		if (Vector3.Distance(transform.position, origin) < 0.05f || nextHover == true) {
			transform.position = Vector3.Slerp(transform.position, target, levSpeed * Time.deltaTime);
			nextHover = true;
		} 
		//makes object move down
		if (Vector3.Distance(transform.position, target) < 0.05f || nextHover == false) {
			transform.position = Vector3.Slerp(transform.position, origin, levSpeed * Time.deltaTime);
			nextHover = false;
		}
	}
	
	//This method doesn't seem to work.
	IEnumerator levitating () {


		Debug.Log("starting levitation");
		transform.position = Vector3.Lerp(transform.position, target, levSpeed * Time.deltaTime);
		yield return null;

		Debug.Log("Levitation Next Step");
		transform.position = Vector3.Lerp(transform.position, origin, levSpeed *Time.deltaTime); 
		yield return null;

		nextHover = true;

	
	}
}
