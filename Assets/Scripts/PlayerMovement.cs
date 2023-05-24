using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	bool isGrounded;
    const float groundDistance = 0.4f;
	const float gravity = -9.81f;
	Vector3 velocity;
    public float turnSpeed = 180f;
    public float speed = 12f;
	public float jumpHeight = 3f;
	public CharacterController controller;
	public Transform groundCheck;
    public LayerMask groundMask;

    // Update is called once per frame
    void Update()
    {
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
			velocity.y = -2f;
		if (Input.GetButtonDown("Jump") && isGrounded)
				velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);

		// FP controls
        if (CamSwitcher.mainMode) {
			
			float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 movement = transform.right * x + transform.forward * z;
            controller.Move(movement * speed * Time.deltaTime);	

		// TP controls	
        } else { 
        	Vector3 movDir;
        	transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
        	movDir = transform.forward * Input.GetAxis("Vertical") * speed;
        	controller.Move(movDir * Time.deltaTime);
        }
    }
}
