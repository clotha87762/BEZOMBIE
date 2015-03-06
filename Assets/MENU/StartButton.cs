using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	
	// Use this for initialization
	public Animator ani;
	
	void Start () {
		ani =GetComponent<Animator> ();
		
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
		Application.LoadLevel ("scene");
	}
	
}
