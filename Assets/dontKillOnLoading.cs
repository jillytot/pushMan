using UnityEngine;
using System.Collections;

public class dontKillOnLoading : MonoBehaviour {

	void Awake () {
		
		//game object won't die on level loading. Be cery carefull with this...
		DontDestroyOnLoad(this.gameObject);
	}
}