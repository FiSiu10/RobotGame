using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	private int score;
	[SerializeField] private Text scoreValue;

	public int _health;
	[SerializeField] private Image healthBar;

	[SerializeField] private OptionsPopup optionsPopup;

	[SerializeField] private SettingsPopup settingsPopup;

	[SerializeField] private GameOverScreen gameOverScreen;

	[SerializeField] private WelcomeScreen welcomeScreen;

	[SerializeField] private DoorPopup doorPopup;

	// Use this for initialization
	void Start () {
		
		//close options pop-up on start of game
		settingsPopup.Close();
		optionsPopup.Close();
		doorPopup.Close ();
		welcomeScreen.Open();

		score = 0;
		scoreValue.text = score.ToString ();

		_health = 5;
		healthBar.fillAmount = 1.0f;
		healthBar.color = Color.green;

		gameOverScreen.Close ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape") 
			&& !settingsPopup.IsActive() 
			&& !optionsPopup.IsActive() 
			&& !gameOverScreen.IsActive()
		) {
			optionsPopup.Open ();
		}

	}

	void Awake(){
		Messenger.AddListener (GameEvent.ENEMY_DEAD, OnEnemyDead);
		Messenger.AddListener (GameEvent.HIT_HEALTH, OnHitHealth);
		Messenger<int>.AddListener (GameEvent.HEALTH_CHANGED, OnHealthAdd);
		Messenger.AddListener (GameEvent.PLAYER_DEAD, OnPlayerDead);
		Messenger<int>.AddListener (GameEvent.FULL_HEALTH, OnFullHealth);

	}

	void OnEnemyDead(){
		score++;
		scoreValue.text = score.ToString ();
	}
		
	void OnHealthAdd(int newHealth){
		healthBar.fillAmount += 0.4f;
		if (newHealth == 5){
			healthBar.color = Color.green;
		}			
		if (newHealth < 4 && newHealth >= 2) {
			healthBar.color = Color.yellow;
		}
		if (newHealth < 2){
			healthBar.color = Color.red;
		}
	}

	void OnHitHealth(){
		healthBar.fillAmount -= 0.2f;
		if (healthBar.fillAmount >= 0.4f && healthBar.fillAmount <= 0.6f){
			healthBar.color = Color.yellow;
		}
		if (healthBar.fillAmount < 0.4f){
			healthBar.color = Color.red;
		}
	
	}

	void OnFullHealth(int health){
		if (health == 5) {
			healthBar.fillAmount = 1.0f;
			healthBar.color = Color.green;
		}
	}

	private void OnPlayerDead(){
		gameOverScreen.Open ();
	}

	void OnDestroy(){
		Messenger.RemoveListener (GameEvent.ENEMY_DEAD, OnEnemyDead);
		Messenger.RemoveListener (GameEvent.HIT_HEALTH, OnHitHealth);
		Messenger<int>.RemoveListener (GameEvent.HEALTH_CHANGED, OnHealthAdd);
		Messenger.RemoveListener (GameEvent.PLAYER_DEAD, OnPlayerDead);
		Messenger<int>.RemoveListener (GameEvent.FULL_HEALTH, OnFullHealth);
	}
}
