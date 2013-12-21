using UnityEngine;
using System.Collections;

public class gemCounter : MonoBehaviour {

	public string gemText; 
	public int displayGemValue;
	public string gemMessage;

	// Use this for initialization
	void Start () {

		GetComponent<TextMesh>().text = gemMessage;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
