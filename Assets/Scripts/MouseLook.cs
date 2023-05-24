using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{
	float rotationX = 0f;
	public float mouseSensitivity = 100f;
	public Transform playerBody;
	
	// Start is called before the first frame update
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update()
	{
		
		if (CamSwitcher.mainMode) {
			float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
			float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
			rotationX -= mouseY;
			rotationX = Mathf.Clamp(rotationX, -90f, 90f);
			transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
			playerBody.Rotate(Vector3.up * mouseX);
		}

	}
}
