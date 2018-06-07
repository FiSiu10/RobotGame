using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour {
	
	public float speed = 6;

	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		PlayerCharacter player = other.GetComponent<PlayerCharacter> ();
		if (player != null) {
			player.Hit ();
			Messenger.Broadcast (GameEvent.HIT_HEALTH);
		}
		Destroy (this.gameObject);
	}

}
