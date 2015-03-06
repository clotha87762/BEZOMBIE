using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {


	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void ChangeSpeed(float newspeed){
		Animator anim = GetComponent<Animator>();
		anim.speed=newspeed;

	}
}

