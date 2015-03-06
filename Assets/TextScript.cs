using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextScript : MonoBehaviour {

	// Use this for initialization
	public Text t;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DetermineText(bool isPause){

		if (isPause) {
			t=GetComponent<Text>();
			t.text = "Pause" 	;	
		} 
		else {
			t=GetComponent<Text>();
			t.text = "GameOver" ;

		}
	}
}
