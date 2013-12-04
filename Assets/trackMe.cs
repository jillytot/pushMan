using UnityEngine;
using System.Collections;

public class trackMe : MonoBehaviour {


	public static float playerPosX; //used for camera tracking
	public static float playerPosZ; //used for camera tracking
	public static trackMe trackThis;

	// Use this for initialization
	void Start () {

		//Consider moving this to a new code snippet so it does not interffer with future mechanics...
		playerPosX = transform.position.x; //easily allows the player's position to be tracked. (currently by the CameraFX.cs)
		//print (playerPosX);
		playerPosZ = transform.position.z; //easily allows the players position to be tracked (currently by the CameraFX.cs)
		//print (playerPosZ);
		
	}
	
	// Update is called once per frame
	void Update () {

		//Let's update our position so we can be tracked by the camera.
		playerPosX = transform.position.x; 
		//print (playerPosX);
		playerPosZ = transform.position.z;
		//print (playerPosZ);
	}
}
