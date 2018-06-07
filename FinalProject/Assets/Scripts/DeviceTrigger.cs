using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceTrigger : MonoBehaviour {

	[SerializeField] private GameObject device;
	[SerializeField] private DoorPopup doorPopup;

	void OnTriggerEnter (Collider other){
		DoorControl door = device.GetComponent<DoorControl> ();
		if (door != null) {
			door.Operate ();
		}
		doorPopup.Open ();
	}

	void OnTriggerExit(Collider other){
		DoorControl door = device.GetComponent<DoorControl> ();
		if (door != null) {
			door.Operate ();
		}
	}
		
}
