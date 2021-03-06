﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 2f;  			// The speed that the player will move at.
//	public float maxJumpHeight = 6f;
	public float jumpVelocity = 6f;
	public bool isGrounded = true;
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
//	CapsuleCollider playerCollider;

	void Awake ()
	{
		playerRigidbody = GetComponent <Rigidbody> ();
//		playerCollider = GetComponent<CapsuleCollider> ();
	}


	void OnCollisionStay (Collision collisionInfo)
	{
		isGrounded = true;
	}

	void OnCollisionExit (Collision collisionInfo)
	{
		isGrounded = false;
	}

	void Update ()
	{
		// Store the input axes.
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");
//		float y = transform.position.y;

		Debug.Log ("Transform tag is " + tag);


		if (Input.GetKeyDown ("space") && isGrounded) {
			print ("space key was pressed");
			playerRigidbody.velocity = Vector3.up * jumpVelocity;
		
		}


		Move (moveHorizontal, 0f, moveVertical);




		// Turn the player to face the mouse cursor.
//		Turning ();

		// Animate the player.
//		Animating (h, v);
	}

	void Move (float x, float y, float z)
	{
		// Set the movement vector based on the axis input.
		movement.Set (x, y, z);

		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * speed * Time.deltaTime;

		// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition (transform.position + movement);
	}

//	void Turning ()
//	{
//		// Create a ray from the mouse cursor on screen in the direction of the camera.
//		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
//
//		// Create a RaycastHit variable to store information about what was hit by the ray.
//		RaycastHit floorHit;
//
//		// Perform the raycast and if it hits something on the floor layer...
//		if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
//		{
//			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
//			Vector3 playerToMouse = floorHit.point - transform.position;
//
//			// Ensure the vector is entirely along the floor plane.
//			playerToMouse.y = 0f;
//
//			// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
//			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
//
//			// Set the player's rotation to this new rotation.
//			playerRigidbody.MoveRotation (newRotation);
//		}
//	}

//	void Animating (float h, float v)
//	{
//		// Create a boolean that is true if either of the input axes is non-zero.
//		bool walking = h != 0f || v != 0f;
//
//		// Tell the animator whether or not the player is walking.
//		anim.SetBool ("IsWalking", walking);
//	}
}