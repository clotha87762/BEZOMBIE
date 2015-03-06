using UnityEngine;
using System.Collections;

public class muteBtn : MonoBehaviour {
	
	// Use this for initialization
	public Animator ani;
	
	void Start () {
		ani =GetComponent<Animator> ();
		if(AudioListener.volume==0.0f)ani.SetBool ("mute", true);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnMouseOver(){
		if (HelpButton.OnHelp == true)
			return;
		
		
		ani.SetBool ("isOver", true);
	}
	
	void OnMouseExit(){
		if (HelpButton.OnHelp == true)
			return;
		ani.SetBool ("isOver", false);
	}
	
	void OnMouseDown(){
		if (HelpButton.OnHelp == true)
			return;
		ani.SetBool ("isDown", true);
		
	}
	
	void OnMouseUp(){
		if (HelpButton.OnHelp == true)
			return;
		ani.SetBool ("isDown", false);
		
	}
	
	void OnMouseUpAsButton(){
		if (HelpButton.OnHelp == true)
			return;
		bool temp = ani.GetBool ("mute");
		AudioListener.volume = (temp) ? 1.0f : 0.0f; 
		ani.SetBool ("mute", !temp);
	}
	
}
