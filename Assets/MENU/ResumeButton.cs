using UnityEngine;
using System.Collections;

public class ResumeButton : MonoBehaviour {

	// Use this for initialization
	public Animator ani;
	void Start () {
		ani =GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseOver(){

		Debug.Log ("QQQ");
		
		ani.SetBool ("isOver", true);
	}
	
	void OnMouseExit(){
		ani.SetBool ("isOver", false);
	}
	
	void OnMouseDown(){
		ani.SetBool ("isDown", true);
	}
	
	void OnMouseUp(){
		ani.SetBool ("isDown", false);
	}
	void OnMouseUpAsButton(){
		
	}
}
