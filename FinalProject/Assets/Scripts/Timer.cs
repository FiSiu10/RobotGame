using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	
	public Text cdtimerText;
	public float timeRemaining;
	private bool timeOut;

	// Use this for initialization
	void Start () {
		cdtimerText.text = "TIME LEFT: 20";
		//timeOut = true;
	}

	void Update () {
		timeRemaining -= Time.deltaTime;
		if (timeRemaining > 0) 
			cdtimerText.text = "TIME LEFT: " + (int)timeRemaining;
		else if (timeRemaining <= 0){
			if (!timeOut)
				Messenger.Broadcast (GameEvent.PLAYER_DEAD);
				timeOut = true;
			}
	}
}
