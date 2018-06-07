using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates { alive, dead };

public class WanderingAI : MonoBehaviour {
	
	public float EnemySpeed { get; set; }
	public float obstacleRange = 5.0f;
	private EnemyStates _state;

	[SerializeField] private GameObject _laserbeamPrefab;
	private GameObject _laserbeam;

	public float fireRate = 2.0f;
	private float nextFire = 0.0f;

	// Use this for initialization
	void Start () {
		_state = EnemyStates.alive;

		EnemySpeed = PlayerPrefs.GetInt ("enemySpeed", 1);
	}
	
	// Update is called once per frame
	void Update () {

		if (_state == EnemyStates.alive) {
			//Move enemy and generate Ray
			transform.Translate (0, 0, EnemySpeed * Time.deltaTime);
			Ray ray = new Ray (transform.position, transform.forward);

			//Spherecast and determine if Enemy needs to turn
			RaycastHit hit;
			if (Physics.SphereCast (ray, 0.75f, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				if (hitObject.GetComponent<PlayerCharacter> ()) {
					//Spherecast hit Player, fire laser!
					if (_laserbeam == null && Time.time > nextFire) {
						nextFire = Time.time + fireRate;
						_laserbeam = Instantiate (_laserbeamPrefab) as GameObject;
						_laserbeam.transform.position = transform.TransformPoint (0, 1.5f, 1.5f);
						_laserbeam.transform.rotation = transform.rotation;
					}
				} else if (hit.distance < obstacleRange) {
					float turnAngle = Random.Range (-110, 110);
					transform.Rotate (0, turnAngle, 0);
				}
			} else {
			}
		}
	}

	public void ChangeState(EnemyStates state){
		_state = state;
	}

	//adds listener to listen for the speed being change (also broadcasts a value)
	void Awake(){
		Messenger<float>.AddListener (GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
	}

	private void OnDifficultyChanged(float enemySpeedInput){
		EnemySpeed = enemySpeedInput; 
	}

	void OnDestroy(){
		Messenger<float>.RemoveListener (GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
	}
}

