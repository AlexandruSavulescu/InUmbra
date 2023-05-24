using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
	Camera firstPersonCam; 
	public static bool mainMode = true;
	public Transform player;
	public Camera thirdPersonCam;
	
	void Start()
	{
		firstPersonCam = Camera.main.GetComponent<Camera>();
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player")) {
			thirdPersonCam.enabled = true;
			firstPersonCam.enabled = false;
			mainMode = false;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player")) {
			thirdPersonCam.enabled = false;
			firstPersonCam.enabled = true;
			mainMode = true;
		}
	}
}
