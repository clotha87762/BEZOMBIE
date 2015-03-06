using UnityEngine;
using System.Collections;

public class BloodG : MonoBehaviour {
	private float timeout;
	private int ran;
	// Use this for initialization
	void Start () {
		timeout = 0;
		ran = Random.Range (0, 4);
		Animator anim = GetComponent<Animator> ();
		switch (ran) {
		case 0:
			anim.SetBool ("BloodGseleter 0",true);
			break;
		case 1:
			anim.SetBool ("BloodGseleter 1",true);
			break;
		case 2:
			anim.SetBool ("BloodGseleter 2",true);
			break;
		case 3:
			anim.SetBool ("BloodGseleter 3",true);
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (PauseControl.play == false) {
			return;
		}


		timeout += Time.deltaTime;
		if (timeout > 2f)
			Destroy (gameObject);
	}
}
