using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {

	private Camera _camera;
	//public int aimSize = 16;
	private bool buttonFreeze;

	// Use this for initialization
	void Start () {
		_camera = GetComponent<Camera> ();
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!buttonFreeze) {
			if (Input.GetMouseButtonDown (0)) {
				Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
				Ray ray = _camera.ScreenPointToRay (point);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					GameObject hitObject = hit.transform.gameObject;
					ReactiveTarget target = hitObject.GetComponent<ReactiveTarget> ();

					//is this object our Enemy?
					if (target != null) {
						target.ReactToHit ();
					} else {
						StartCoroutine (SphereIndicator (hit.point));
					}
				}
			}
		}
	}

	private IEnumerator SphereIndicator(Vector3 hitPosition){
		if (!buttonFreeze) {
			GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			sphere.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			sphere.transform.position = hitPosition;

			yield return new WaitForSeconds (1);

			Destroy (sphere);
		}
	}

	void Awake(){
		Messenger.AddListener (GameEvent.GAME_TIME_CHANGED, OnButtonFreeze);
	}

	private void OnButtonFreeze(){
		buttonFreeze = !buttonFreeze;
	}

	void OnDestroy(){
		Messenger.RemoveListener (GameEvent.GAME_TIME_CHANGED, OnButtonFreeze);
	}


}