using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool jumpCancel = false;
	bool crouch = false;
	bool grounded = false;
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		grounded = controller.getGrounded();

		if (Input.GetButtonDown("Jump") && grounded)
		{
			jump = true;		
		}

		if (Input.GetButtonUp("Jump") && !grounded) 
		{
			jumpCancel = true;
		}


		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, jumpCancel);
		jump = false;
	}
}