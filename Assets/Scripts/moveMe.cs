using UnityEngine;
using System.Collections;

public class moveMe : MonoBehaviour {

	public float mySpeed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		transform.Translate(Vector3.forward * mySpeed * Time.deltaTime);

	}
}
