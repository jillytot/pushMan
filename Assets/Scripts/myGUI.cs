using UnityEngine;
using System.Collections;

public class myGUI : MonoBehaviour {
	
public GUISkin pushStyle;
public string showGems = "Pushman the Game";
		
void OnGUI () {

		GUI.skin = pushStyle;
		GUI.Label (new Rect (10,10,200,80), showGems + Adventurer.guiGemCount);
		GUI.Label (new Rect (10,30,200,80),"Key Count: " + Adventurer.guiKeyCount);

		if (Adventurer.pickAxe == true) {
	
		GUI.Label (new Rect (10,50,200,80),"Pick Axe");

		}
	}
}
