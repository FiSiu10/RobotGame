using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour {
	
	private CharacterController _charController;
	public float gravity = -9.8f;
	public float pushForce = 5.0f;

	// Use this for initialization
	void Start () {
		_charController = GetComponent<CharacterController> ();	
	}

	public float speed = 9.0f;
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;

		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);

		//Clamp magnitude for diagonal movement
		movement = Vector3.ClampMagnitude (movement, speed);

		movement.y = gravity;

		//Movement code Frame Rate Independent
		movement *= Time.deltaTime;

		// Conver local to global coordinates
		movement = transform.TransformDirection(movement);

		_charController.Move (movement);
	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		Rigidbody body = hit.collider.attachedRigidbody;
		//does it have a rigidbody and is Physics enabled?
		if (body != null && !body.isKinematic) {
			body.velocity = hit.moveDirection * pushForce;
		}
	}
}
