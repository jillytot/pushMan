using UnityEngine;
using System.Collections;

public class touchScreenDpad : MonoBehaviour {

	bool forward = false;
	bool back = false;
	bool right = false;
	bool left = false;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		//if (forward == true) {

			//print ("forward hoooo!");
			//var inputUp = new Vector3(0,0,1);
			//Adventurer.inputSignal = inputUp;

		//}
	
	}

	void OnGUI () {

	if (GUI.RepeatButton (new Rect (10,70, 100, 20), "Up")) {
		print ("you clicked Up");

			//forward = Input.GetKeyDown(KeyCode.UpArrow);
			//forward = true;

			//forward = KeyCode.UpArrow;
			forward = true;


			//var inputUp = new Vector3(0,0,1);

			Adventurer.inputSignal += Vector3.forward;

		} else { 

			forward = false;
		
		}

			

		if (GUI.RepeatButton (new Rect (10,90, 100, 20), "Down")) {
			print ("you clicked Down");
			
		}

		if (GUI.RepeatButton (new Rect (10,110, 100, 20), "Left")) {
			print ("you clicked Left");
			
		}

		if (GUI.RepeatButton (new Rect (10,130, 100, 20), "Right")) {
			print ("you clicked Right");
			
		}
	}
}
