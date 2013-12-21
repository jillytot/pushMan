using UnityEngine;
using System.Collections;

public class lookAtCamera : MonoBehaviour {

	public Transform cameraTarget;
	Quaternion myRotation;

	// Use this for initialization
	void Start () {

		myRotation = transform.rotation;
	
	}
	
	// Update is called once per frame
	void Update () {

		cameraTarget = cameraTargeting.cameraTarget.transform;
		//var newRotation = new Vector3(myRotation.x, cameraTarget.y, myRotation.z); 
		//transform.LookAt(cameraTarget);

		transform.LookAt(transform.position + cameraTarget.rotation * Vector3.back,
		                 cameraTarget.transform.rotation * Vector3.up);


	
	}
}
