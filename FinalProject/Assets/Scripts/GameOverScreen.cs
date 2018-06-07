using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

	[SerializeField] private Image crossHair;

	public void Open(){
		//pause game & turn off crosshair
		Time.timeScale = 0;
		crossHair.gameObject.SetActive (false);

		//turn on popup
		this.gameObject.SetActive(true);

		//broadcast event
		Messenger.Broadcast (GameEvent.GAME_TIME_CHANGED);

		//Activate mouse
		Cursor.lockState = CursorLockMode.None;
	}

	public void Close(){
		this.gameObject.SetActive (false);
	}


	public bool IsActive(){
		return this.gameObject.activeSelf;
	}

	public void OnExitGameButton(){
		Application.Quit ();
	}

	// Use this for initialization
	public void OnStartAgainButton () {
		//reload same scene
		SceneManager.LoadScene(0);
		Time.timeScale = 1;
		Messenger.Broadcast (GameEvent.GAME_TIME_CHANGED);
	}
}
