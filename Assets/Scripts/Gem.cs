using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {

	//Stores value for each gem type.
	public int gemValue = 1;
	public bool killGem = false;
	public GameObject gemCounter;
	GameObject myGemCounter;

	void Update () {

		if (killGem == true) {

			//Instantiate(gemCounter, transform.position, transform.rotation);
			myGemCounter = (GameObject)Instantiate(gemCounter, transform.position, transform.rotation);
			myGemCounter.GetComponentInChildren<gemCounter>().gemMessage = "+ " + gemValue;

			Destroy(this.gameObject);

		}
	}
}
	//bool gemDestroy = false;
	