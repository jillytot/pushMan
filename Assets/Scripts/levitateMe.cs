using UnityEngine;
using System.Collections;

public class levitateMe : MonoBehaviour {
	
	Vector3 origin; 
	Vector3 target;
	public float levRange= 1.0f;
	public float levSpeed = 1.0f;
	bool nextHover;

	void Start () {

		origin = transform.position;
		print(origin.y);
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


		//if (nextHover) {

			//nextHover = false;
			//StartCoroutine(levitating());

		//}
	}

		//if (Vector3.Distance(transform.position, target) > 0.05f) {

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
