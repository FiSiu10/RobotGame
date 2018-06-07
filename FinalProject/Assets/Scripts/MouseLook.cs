using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
	// Use this for initialization

	public enum RotationAxes
	{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityHorz = 9.0f;
	public float sensitivityVert = 9.0f;

	public float minVert = -45.0f;
	public float maxVert = 45.0f;

	public float _rotationX = 0.0f;
	private bool gamePaused;

	// Update is called once per frame
	void Update () {
		if (!gamePaused) {
			if (axes == RotationAxes.MouseX) {
				transform.Rotate (0, Input.GetAxis ("Mouse X") * sensitivityHorz, 0);
			} else if (axes == RotationAxes.MouseY) {
				_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
				_rotationX = Mathf.Clamp (_rotationX, minVert, maxVert);

				transform.localEulerAngles = new Vector3 (_rotationX, 0, 0);
			} else {
				_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
				_rotationX = Mathf.Clamp (_rotationX, minVert, maxVert);
				float delta = Input.GetAxis ("Mouse X") * sensitivityHorz;
				float rotationY = transform.localEulerAngles.y + delta;
				transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
			}
		}
	}


	void Awake(){
		Messenger.AddListener (GameEvent.GAME_TIME_CHANGED, onCameraFreeze);
	}

	private void onCameraFreeze(){
		gamePaused = !gamePaused;
		Debug.Log("gamePaused is " + gamePaused);
	}
		
	void OnDestroy(){
		Messenger.RemoveListener (GameEvent.GAME_TIME_CHANGED, onCameraFreeze);
	}
}
