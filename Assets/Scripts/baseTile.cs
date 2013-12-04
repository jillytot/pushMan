using UnityEngine;
using System.Collections;

public class baseTile : MonoBehaviour {

	//This should be a public static variable at some point...
	float tileSize = 2;
	public GameObject wallCollider; // spawns wallCollider around mover if conditions are met

	//Possible places to spawn colliders
	Vector3 rightSpawnPos;
	Vector3 leftSpawnPos;
	Vector3 forwardSpawnPos;
	Vector3 backSpawnPos;

	//Different directions to cast a ray relative to the tile's position
	Vector3 forward;
	Vector3 right;
	Vector3 back;
	Vector3 left;
	
	// Use this for initialization
	void Start () {

		//Shortcut Directions
		forward = transform.TransformDirection(Vector3.forward) * tileSize;
		right = transform.TransformDirection(Vector3.right) * tileSize;
		back = transform.TransformDirection(Vector3.back) * tileSize;
		left = transform.TransformDirection(Vector3.left) * tileSize;


		spawnColliders ();

		
	}
	
	// Update is called once per frame
	void Update () {
		
		//show raycasts
		//Debug.DrawRay(transform.position, right, Color.red, tileSize);
		//Debug.DrawRay(transform.position, left, Color.blue, tileSize);
		//Debug.DrawRay(transform.position, forward, Color.green, tileSize);
		//Debug.DrawRay(transform.position, back, Color.yellow, tileSize);
		
	}


	//spawns colliders around the tile where there are no adjacent tiles
	void spawnColliders () {
		
		//First we determine the position to spawn each collider
		//spawn collider to my right
		rightSpawnPos = transform.position;
		rightSpawnPos.x += tileSize;
		rightSpawnPos.y += tileSize;
		
		//spawn to my left
		leftSpawnPos = transform.position;
		leftSpawnPos.x -= tileSize;
		leftSpawnPos.y += tileSize;
		
		//spawn to my up
		forwardSpawnPos = transform.position;
		forwardSpawnPos.z += tileSize;
		forwardSpawnPos.y += tileSize;
		
		//spawn to my down
		backSpawnPos = transform.position;
		backSpawnPos.z -= tileSize;
		backSpawnPos.y += tileSize;
		
		//Next we do our raycast, if nothing is there, let's spawn our collider
		RaycastHit hit; 
		
		//raycast to the right
		if (Physics.Raycast(transform.position, right, out hit , tileSize)) {
			//Debug.Log("There is something to my right");
		} else {
			//Debug.Log("There is nothing to my right");
			//Spawn collider to my right
			GameObject spawnWallRight = (GameObject)Instantiate(wallCollider, rightSpawnPos, transform.rotation);
		}

		//raycast to the left
		if (Physics.Raycast(transform.position, left, out hit , tileSize)) {
			//Debug.Log("There is something to my left");
		} else {
			//Debug.Log("There is nothing to my left");
			//spawn collider to my left
			GameObject spawnWallLeft = (GameObject)Instantiate(wallCollider,leftSpawnPos, transform.rotation);
		}
		
		//raycast to up
		if (Physics.Raycast(transform.position, forward, out hit , tileSize)) {
			//Debug.Log("There is something to my up");
		} else {
			//Debug.Log("There is nothing to my up");
			//spawn collider up (north)
			GameObject spawnWallForward = (GameObject)Instantiate(wallCollider, forwardSpawnPos, transform.rotation);
		}
		
		//raycast to down
		if (Physics.Raycast(transform.position, back, out hit , tileSize)) {
			//Debug.Log("There is something to my down");
		} else {
			//Debug.Log("There is nothing to my down");
			//spawn collider down (south)
			GameObject spawnWallBack = (GameObject)Instantiate(wallCollider, backSpawnPos, transform.rotation);
		} 
	}
}
