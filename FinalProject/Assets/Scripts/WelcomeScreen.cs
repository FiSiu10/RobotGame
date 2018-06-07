using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WelcomeScreen : MonoBehaviour {
	[SerializeField] private Image crossHair;
	[SerializeField] private WelcomeScreen welcomeScreen;
	[SerializeField] private Text welcomeText;


	// Use this for initialization
	public void Open () {
		//pause game & turn off crosshair
		Time.timeScale = 0;

		crossHair.gameObject.SetActive (false);
		Cursor.lockState = CursorLockMode.None;

		//turn on popup
		this.gameObject.SetActive(true);

		//broadcast event
		Messenger.Broadcast (GameEvent.GAME_TIME_CHANGED);

	}

	public void Close(){
		this.gameObject.SetActive (false);
		crossHair.gameObject.SetActive(true);
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void OnStartButton(){
		//SceneManager.LoadScene(0);
		Time.timeScale = 1;
		Close ();
		Messenger.Broadcast (GameEvent.GAME_TIME_CHANGED);
	}

	public bool IsActive(){
		return this.gameObject.activeSelf;
	}
}
