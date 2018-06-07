using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {
	public int health;
	public int maxHealth = 5;

	// Use this for initialization
	void Start () {
		health = 5;
	}
	
	// Update is called once per frame
	public void Hit () {
		health -= 1;
		Debug.Log ("Health: " + health);
		if (health == 0) {
			//Debug.Break ();
			Messenger.Broadcast(GameEvent.PLAYER_DEAD);
		}
	}

	public void FirstAid(){
		if (health < maxHealth) {
			health += 2;
			if (health > maxHealth) {
				health = maxHealth;
			}
			Messenger<int>.Broadcast (GameEvent.HEALTH_CHANGED, health);
		}
	}

	public void FullHealth(){
		health = 5;
		Messenger<int>.Broadcast (GameEvent.FULL_HEALTH, health);
	}

	public void NoHealth(){
		health = 0;
		Messenger.Broadcast (GameEvent.PLAYER_DEAD);
	}
		
}
