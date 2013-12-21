using UnityEngine;
using System.Collections;

public class fadeOut : MonoBehaviour {

	//Fade the alpha of the renderer over time

	public Color fontColor;
	public Color newColor;
	public float fadeRate = 1;
	float startTime;
	public float delayFade = 1;
	bool doTheLerp = false;
	

	// Use this for initialization
	void Start () {

		//Initialize the font color as the starting color
		fontColor = renderer.material.color;

		//normalize start time
		startTime = Time.time + delayFade;

		//Inititalize the new color.
		newColor =  new Color(fontColor.r, fontColor.g, fontColor.b, 0);

		//enables the fade fuction after a set time
		StartCoroutine("fadeTrigger");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (doTheLerp == true) {

		lerpColor ();

		}
	}

	//Changes color from one value to the other
	void lerpColor () {

		//decrease the alpha by larger values over time, and use fadeRate as a scaling factor
		var lerpMe = (Time.time - startTime) / fadeRate;
		renderer.material.color = Color.Lerp(fontColor, newColor, lerpMe);

	}

	IEnumerator fadeTrigger () {

		yield return new WaitForSeconds(delayFade);
		doTheLerp = true;
	}
}
