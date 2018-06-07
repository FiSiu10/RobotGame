using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingIguana : MonoBehaviour {

	public float iguanaSpeed = 3.0f;
	public float obstacleRange = 5.0f;

	private Animator iguanaAnimator;
	// Use this for initialization
	void Start () {
		iguanaAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		iguanaAnimator.speed = iguanaSpeed;

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		//Spherecast to determine if need to turn
		if (Physics.SphereCast (ray, 0.25f, out hit)) {
			if (hit.distance < obstacleRange) {
				//Must've hit wall or other object, turn
				float turn = Random.Range (-0.1f, 1.0f);
				Move (turn, 1.0f);
			} else {
				float forward = Random.Range (0.15f, 1.0f);
				Move (0.0f, forward);
			}
		}
	}

	private void Move(float x, float y){
		if (iguanaAnimator != null){
			iguanaAnimator.SetFloat("Turn", x, 0.2f, Time.deltaTime);
			iguanaAnimator.SetFloat("Forward", y, 0.2f, Time.deltaTime);
		}
	}
}
