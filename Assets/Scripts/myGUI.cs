using UnityEngine;
using System.Collections;

public class myGUI : MonoBehaviour {
	
public GUISkin pushStyle;
public string showGems = "Pushman the Game";
		
void OnGUI () {
		GUI.skin = pushStyle;
		GUI.Label (new Rect (10,10,200,80), showGems + Adventurer.gemCount);
		GUI.Label (new Rect (10,25,200,80),"Key Count: " + Adventurer.keyCount);

		if (Adventurer.pickAxe == true) {
	
		GUI.Label (new Rect (10,50,200,80),"Pick Axe");

		}
	}
}
