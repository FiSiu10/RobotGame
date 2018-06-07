using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorPopup : MonoBehaviour {
	[SerializeField] private Image crossHair;

	// Use this for initialization
	public void Open(){
		Time.timeScale = 0;
		crossHair.gameObject.SetActive (false);
		Cursor.lockState = CursorLockMode.None;
		//turn on popup
		gameObject.SetActive(true);
		// broadcast event
		Messenger.Broadcast (GameEvent.GAME_TIME_CHANGED);
	}

	public void Close(){
		//turn off popup & turn on crosshair
		gameObject.SetActive(false);
		crossHair.gameObject.SetActive(true);
		//lock the mouse cursor to centre of view
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void OnReturnToGameButton(){
		//unpause game & close popup
		Time.timeScale = 1;
		Close();
		Messenger.Broadcast (GameEvent.GAME_TIME_CHANGED);
	}

	public bool IsActive(){
		return this.gameObject.activeSelf;
	}
}
 