using UnityEngine;
using System.Collections;

public class trollStar : MonoBehaviour {

	public static trollStar starInst;
	public bool showMessage = false;
	bool messageDisplayed = false;
	public GameObject trollMessage;
	public GameObject trollsound;

	// Use this for initialization
	void Awake () {

		starInst = this;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (showMessage == true && messageDisplayed == false) {

			GameObject haha = (GameObject)Instantiate(trollMessage, transform.position, transform.rotation);
			GameObject hoho = (GameObject)Instantiate(trollsound, transform.position, transform.rotation);
			messageDisplayed = true;

		}
	}
}
