using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, 3);
	}

	void OnTriggerEnter(Collider other){
		PlayerCharacter player = other.GetComponent<PlayerCharacter> ();
		if (player != null) {
			//apply first-aid and remove the item
			player.FirstAid();
			Destroy (this.gameObject);
		}
	}
}
