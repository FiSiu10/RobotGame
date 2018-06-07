using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject _enemyPrefab;
	private GameObject _enemy;
	private GameObject _enemy2;
	private GameObject[] enemies;
	private GameObject[] enemies2;
	public int numEnemies;

	[SerializeField] private GameObject _iguanaPrefab;
	private GameObject _iguana;
	private GameObject[] iguanas;
	public int numIguanas;

	private float enemySpeed = 3.0f;

	void Start(){
		enemies = new GameObject[numEnemies];
		enemies2 = new GameObject[numEnemies];
		iguanas = new GameObject[numIguanas];

		for (int i = 0; i < iguanas.Length; i++){
			if (iguanas[i] == null) {
				_iguana = Instantiate (_iguanaPrefab) as GameObject;
				_iguana.transform.position = new Vector3 (0, 0, 0);
				float angle = Random.Range (0, 360);
				_iguana.transform.Rotate (0, angle, 0);
				iguanas [i] = _iguana;
			}
		}
	}


	// Update is called once per frame
	void Update () {
		for (int i = 0; i < enemies.Length; i++){
			if (enemies[i] == null) {
				_enemy = Instantiate (_enemyPrefab) as GameObject;
				_enemy.GetComponent<WanderingAI> ().EnemySpeed = enemySpeed;
				_enemy.transform.position = new Vector3 (5, 0, 15);
				float angle = Random.Range (0, 360);
				_enemy.transform.Rotate (0, angle, 0);
				enemies [i] = _enemy;
			}
		}
		for (int i = 0; i < enemies2.Length; i++){
			if (enemies2[i] == null) {
				_enemy2 = Instantiate (_enemyPrefab) as GameObject;
				_enemy2.GetComponent<WanderingAI> ().EnemySpeed = enemySpeed;
				_enemy2.transform.position = new Vector3 (-5, 0, -10);
				float angle = Random.Range (0, 360);
				_enemy2.transform.Rotate (0, angle, 0);
				enemies2 [i] = _enemy2;
			}
		}
	}

	void Awake(){
		Messenger<float>.AddListener (GameEvent.DIFFICULTY_CHANGED, OnSpeedChanged);
	}

	private void OnSpeedChanged(float speed){
		enemySpeed = speed;
	}

	void OnDestroy(){
		Messenger<float>.RemoveListener (GameEvent.DIFFICULTY_CHANGED, OnSpeedChanged);
	}
}