using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour {

	[SerializeField] private OptionsPopup optionsPopup;
	[SerializeField] private Slider slider;
	[SerializeField] private Text numSpeedValue;
	[SerializeField] private Image crossHair;

	// Use this for initialization
	void Start () {
		//optionsPopup.Close ();
		slider.value = PlayerPrefs.GetInt ("enemySpeed", 1);
		numSpeedValue.text = ((int)slider.value).ToString ();
	}

	public void Open(){
		//turn on popup
		gameObject.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		crossHair.gameObject.SetActive (false);
	}

	public void Close(){
		//turn off popup 
		gameObject.SetActive(false);
	}
	
	public void OnOKButton(){
		//close this popup and re-open options popup
		Close ();
		optionsPopup.gameObject.SetActive (true);
		//save slider setting
		PlayerPrefs.SetInt ("enemySpeed", (int)slider.value);
		Messenger<float>.Broadcast (GameEvent.DIFFICULTY_CHANGED, slider.value);
	}

	public void OnCancelButton(){
		Close ();
		optionsPopup.gameObject.SetActive (true);
	}

	public void OnDifficultyValue(float enemySpeed){
		numSpeedValue.text = enemySpeed.ToString ();
	}

	public bool IsActive(){
		return this.gameObject.activeSelf;
	}
}
