using UnityEngine;
using System.Collections;

public class HelpButton : MonoBehaviour {
	public static bool OnHelp;
	// Use this for initialization
	public Animator ani;
	void Start () {
		OnHelp = false;
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
		if (HelpButton.OnHelp == true  )
			return;
		ani.SetBool ("isDown", true);
	}
	
	void OnMouseUp(){
		if (HelpButton.OnHelp == true)
			return;
		ani.SetBool ("isDown", false);
		
		OnHelp = true;
	}
	void OnMouseUpAsButton(){
		
	}
}
