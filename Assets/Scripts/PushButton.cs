using UnityEngine;
using System.Collections;

public class PushButton : MonoBehaviour {
	
	// Use this for initialization
	public bool pressed;
	public Animator ani;
	public Zombie zombie;
	public ManManager mmgr;
	private float timec;
	public bool cflag;
	public static float slowSpeed;
	
	void Start () {
		pressed = false;
		ani = GetComponent<Animator> ();
		cflag = true;
		timec = 0;
		slowSpeed = 0.05f;
	}
	
	// Update is called once per frame
	void Update () {

		if (PauseControl.play == false) {
			return;
		}


		if(Input.GetKeyDown (KeyCode.S)){
			ani.SetBool ("Pressed", true);
			pressed = true;
			zombie.PlusSpeed (0.3f);

			setHumansSlow();
		}
		
		
		
		if(Input.GetMouseButtonUp(0)&&pressed==true){
			ani.SetBool ("Pressed", false);
			pressed = false;
		}
		else if(Input.GetKeyUp (KeyCode.S)){
			ani.SetBool ("Pressed", false);
			pressed = false;
		}
		
		zombie.PlusSpeed (Time.deltaTime*-2);

		if (timec > 0.15f ) {
			if(pressed == true){
				cflag=true;
				timec=0;
			}
		}
		else
			timec += Time.deltaTime;

	}
	
	void setHumansSlow(){
		if (cflag == false) {
			return;
		}
		else
			cflag = false;
		foreach(human man in mmgr.men)
		{
			man.OnSlow(human.maxhumanspeed*slowSpeed+0.05f);
		}

	}
	
	
	
	void OnMouseDown(){
		
		if (PauseControl.play == false) {
			return;
		}


		ani.SetBool ("Pressed", true);
		pressed = true;
		zombie.PlusSpeed (0.3f);
		setHumansSlow ();
		
		
	}
	void OnMouseUp(){
		
	}
	void OnMouseDrag(){
		
	}
	
}
