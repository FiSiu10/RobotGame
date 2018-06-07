using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoType : MonoBehaviour {

	public float letterPause = 1.0f;
	Text txt;
	string message;

	void Awake () {
		//message = {'h', 'e'};
		//message = gameObject.GetComponent<Text>().text;
		txt = gameObject.GetComponent<Text>();
		message = txt.text; 
		txt.text = "";
		//StartCoroutine ("TypeText");
	}

	void Update(){
		StartCoroutine(TypeText());
	}

	IEnumerator TypeText () {
		//char[] array = message.ToCharArray();
		//char[] array = {'h', 'e', '\0'};
		//int i = 0;
//		while (i < array.Length){
//			char letter = array [i];
//			gameObject.GetComponent<Text>().text += letter;
//			i++;
//			yield return new WaitForSeconds (letterPause);
//		}
		foreach (char c in message) {
			txt.text += c;
			yield return new WaitForSeconds (0.125f);
		}
		  
	}
}
