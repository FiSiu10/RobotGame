using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour {

	private bool doorIsOpen;

	// Use this for initialization
	void Start () {
		doorIsOpen = false;
	}
	
	// Update is called once per frame
	public void Operate () {
		if (doorIsOpen) {
			iTween.MoveTo (this.gameObject, new Vector3 (9.29f, 0, -14.24f), 5);
		} else {
			iTween.MoveTo (this.gameObject, new Vector3 (6.80f, 0, -14.48f), 5);
		}
		doorIsOpen = !doorIsOpen;
	}
}
