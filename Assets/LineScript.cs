using UnityEngine;
using System.Collections;

public class LineScript : MonoBehaviour {


	public Animation line;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.S)){
		
			Animator anim = GetComponent<Animator>();
			anim.SetBool("stop",false);
		}
		if(Input.GetKeyUp(KeyCode.S)){
			Animator anim = GetComponent<Animator>();
			anim.SetBool("stop",true);

		}

	}
}
