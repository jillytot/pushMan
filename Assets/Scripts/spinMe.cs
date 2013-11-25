using UnityEngine;
using System.Collections;

public class spinMe : MonoBehaviour {

	public int x;
	public int y;
	public int z;
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (x,y,z * rotationSpeed * Time.deltaTime);
	
	}
}
