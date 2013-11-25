using UnityEngine;
using System.Collections;

/* public static class JillsCustomExtensions {
	public static Quaternion EaseTowards(this Quaternion curr, Quaternion target, float easing) {
		return Quaternion.Slerp(curr, target, Mathf.Pow(easing, Mathf.Clamp01(60f * Time.deltaTime)));
	}
}

public class characterController : MonoBehaviour {

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	Rigidbody newbody; // = controller.attachedRigidbody;
	public float turnSpeed = 0.2f;

	void Awake() {

		new Rigidbody body = GetComponent<CharacterController>().attachedRigidbody;
	}

	void Update() {

		/*var inputSignal = new Vector3(
			Input.GetAxisRaw("Horizontal"),
			0,
			Input.GetAxisRaw("Vertical")
			);

		if (inputSignal.sqrMagnitude > 0.05f * 0.05f) {
			//body.MovePosition(body.position + (moveSpeed * Time.deltaTime) * inputSignal);
			var targetRotation = Quaternion.LookRotation(inputSignal);
			body.MoveRotation( body.rotation.EaseTowards(targetRotation, turnSpeed) ); 


		CharacterController controller = GetComponent<CharacterController>();
		//body = controller.attachedRigidbody;
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			var targetRotation = Quaternion.LookRotation(moveDirection);
			//transform.rotation = targetRotation; // lame sauce... 
			body.MoveRotation(body.rotation.EaseTowards(targetRotation, turnSpeed) ); 
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
		}
	} */
