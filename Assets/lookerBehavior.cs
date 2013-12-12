using UnityEngine;
using System.Collections;

public enum direction { //creating an index of default directions things can go

	NONE,
	NORTH,
	SOUTH,
	EAST,
	WEST,
	NW,
	SW,
	NE,
	SE,

}

public class lookerBehavior : MonoBehaviour {

	public direction myDirection; //Ultimlately tells Looker where to go

	//tile size is important for movement math.
	float tileSize = 2;

	//Creating a list of Vector3 directions to tie to direction index
	Vector3 forward;
	Vector3 right;
	Vector3 back;
	Vector3 left;
	Vector3 targetPos; //desired position
	Vector3 curr; //current position.
	
	bool moveMe = false; //if true, then looker will move.
	bool moveReady = false; //Returns true when the looker is ready to move again

	//How fast the looker moves
	public float speed = 1; //How fast do i move?
	public float turnSpeed = 0.1f; //How fast do i turn?
	public float moveRate = 2; //How often do i move?

	//List of possible directions the Looker can move in.
	public ArrayList possibleDirections;

	// Use this for initialization
	void Start () {

		//shortcuts for going directions.
		forward = transform.TransformDirection(Vector3.forward) * tileSize;
		right = transform.TransformDirection(Vector3.right) * tileSize;
		back = transform.TransformDirection(Vector3.back) * tileSize;
		left = transform.TransformDirection(Vector3.left) * tileSize;

		//Makes different lookers start at different times.
		StartCoroutine("offsetStartTime");
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//If looker is ready to move, move the looker.
		if (moveMe == false && moveReady == true) {

			StartCoroutine ("movementRate");
			moveReady = false;
		}

		//If i am moving, telll me where to move.
		if (moveMe == true) {

			availableDIrections ();
			//showRaycasts();

			moveMe = false;
			moveReady = true;
		}

		//Once i know where to move, go ahead and move there.
		if (moveMe == false) {

			//goToThere = false;
			//StartCoroutine ("moveCounter");
			lookerMovement ();

		}
	}

	//Check to see what's around me.
	//If there is nothing around me, add that direction to the list of possible directions.
	void availableDIrections () {

		RaycastHit hit; //Make a raycast hit.

		//Debug.Log ("Checking Directions...");

		//refresh the array with the list of possible directions
		possibleDirections = new ArrayList();
		possibleDirections.Add(direction.NONE);

		if (Physics.Raycast(transform.position, forward, out hit, tileSize)) {

			//Debug.Log("There is something in font of me");
		
		} else { 

			//If this direction is open to move into, add it to the possibleDirections array...
			possibleDirections.Add(direction.NORTH);
			//Debug.Log ("There is nothing in front of me...");

		}

		if (Physics.Raycast(transform.position, right, out hit, tileSize)) {

			//Debug.Log("There is something to my right");
		
		} else { 

			possibleDirections.Add(direction.EAST);	
			//Debug.Log ("There is nothing to my right...");
				
		}

		if (Physics.Raycast(transform.position, back, out hit, tileSize)) {

			//Debug.Log("There is behind me");

		} else { 

			possibleDirections.Add(direction.SOUTH);
			//Debug.Log ("There is nothing behind me...");
				
		}

		if (Physics.Raycast(transform.position, left, out hit, tileSize)) {

			//Debug.Log("There is something to my left");

		} else { 

			possibleDirections.Add(direction.WEST);
			Debug.Log ("There is nothing to my left...");
		}

		//Debug.Log ("Done Checking Directions...");

		//Take the arraylist of open directions, and randomly chose one to go to.
		myDirection = (direction) possibleDirections[Random.Range(0, possibleDirections.Count)];
		//store current position before starting movement.
		curr = transform.position;
	}

	//Once i have a direciton to go, move in that direction, and rotate the looker to face the direction that it's going.
	void lookerMovement () {

		//Shortcuts for facing directions
		var faceNorth = Quaternion.LookRotation(forward);
		var faceSouth = Quaternion.LookRotation(back);
		var faceWest = Quaternion.LookRotation(left);
		var faceEast = Quaternion.LookRotation(right);

		//based on myDirection, rotate and go towards that direction.
		switch (myDirection) {

		case direction.NORTH:

			//print ("I'll go north");
			targetPos = curr + forward;
			transform.position = Vector3.Slerp(transform.position, targetPos, speed * Time.deltaTime);
			rigidbody.MoveRotation(rigidbody.rotation.EaseTowards(faceNorth, turnSpeed));

			break;

		case direction.EAST:

			//print ("I'll go east");
			targetPos = curr + right;
			transform.position = Vector3.Slerp(transform.position, targetPos, speed * Time.deltaTime);
			rigidbody.MoveRotation(rigidbody.rotation.EaseTowards(faceEast, turnSpeed));

			break;
		
		case direction.SOUTH:

			//print ("I'll go south");
			targetPos = curr + back;
			transform.position = Vector3.Slerp(transform.position, targetPos, speed * Time.deltaTime);
			rigidbody.MoveRotation(rigidbody.rotation.EaseTowards(faceSouth, turnSpeed));

			break;
		
		case direction.WEST:

			//print ("I'll go west");
			targetPos = curr + left;
			transform.position = Vector3.Slerp(transform.position, targetPos, speed * Time.deltaTime);
			rigidbody.MoveRotation(rigidbody.rotation.EaseTowards(faceWest, turnSpeed));

			break;

		default:

			//print ("i'm not going anywhere for now..");

			break;
		}

		//possibleDirections.RemoveAt();
		//Debug.Log("Possible Directions Index:  " + possibleDirections.Count);
	}
	
	//Not currently used for anything...
	direction getDirection (direction dir) {

		direction thisDirection = direction.EAST;

		return thisDirection;
	}

	//Use this to make sure things are working.
	void showRaycasts () {
		
		//show raycasts
		Debug.DrawRay(transform.position, right, Color.red, tileSize);
		Debug.DrawRay(transform.position, left, Color.blue, tileSize);
		Debug.DrawRay(transform.position, forward, Color.green, tileSize);
		Debug.DrawRay(transform.position, back, Color.yellow, tileSize);

		for (int i = 0; i < possibleDirections.Count; i++) {

			Debug.Log (possibleDirections[i]);

		}
	}

	//Sets the timer for how long between each movement cycle.
	IEnumerator movementRate () {

		yield return new WaitForSeconds (moveRate);
		yield return new WaitForFixedUpdate();
		moveMe = true;
	}

	//If there are mulltiple lookers, it keeps them all from moving at the same time.
	IEnumerator offsetStartTime () {

		yield return new WaitForSeconds (Random.Range(0,moveRate));
		yield return new WaitForFixedUpdate();
		moveReady = true;

	}
}
