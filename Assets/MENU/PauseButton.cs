using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	// Use this for initialization
	public Animator ani;
	public PauseScript pauseMenu;
	void Start () {
		ani =GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void QQQ(){
		ani.SetBool ("isDown", false);
	}



	void OnMouseOver(){
		if (PauseControl.play == false) {
			return;
		}


		ani.SetBool ("isOver", true);
	}
	
	void OnMouseExit(){


		ani.SetBool ("isOver", false);
	}
	
	void OnMouseDown(){
		if (PauseControl.play == false) {
			return;
		}

		ani.SetBool ("isDown", true);
	}
	
	void OnMouseUp(){



		ani.SetBool ("isDown", false);
	}
	void OnMouseUpAsButton(){
		if (PauseControl.play == false) {
			return;
		}

		pauseMenu.GoToScreen ();
	}


}
