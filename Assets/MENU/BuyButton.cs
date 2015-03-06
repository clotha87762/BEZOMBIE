using UnityEngine;
using System.Collections;

public class BuyButton : MonoBehaviour {
	public static bool onBuy;
	// Use this for initialization
	public Animator ani;
	void Start () {
		onBuy = false;
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
		
		onBuy = true;
		
	}
	void OnMouseUpAsButton(){
		
	}
}
