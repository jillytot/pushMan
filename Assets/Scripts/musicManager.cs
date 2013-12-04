using UnityEngine;
using System.Collections;

public class musicManager : MonoBehaviour {
	

	void Awake () {

		//Music won't cut off when transitioning to a new scene...
		DontDestroyOnLoad(this.gameObject);
	
	}
}
