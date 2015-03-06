using UnityEngine;
using System.Collections;

public class skin : MonoBehaviour {
	void Start(){
		Animator anim=gameObject.GetComponent<Animator>();
		int num = PlayerPrefs.GetInt("equalSkin");
		Debug.Log (num);
		if (num == 1)
			anim.SetBool ("skin 1", true);
		else
			anim.SetBool ("skin 1", false);
		if (num == 2)
			anim.SetBool ("skin 2", true);
		else
			anim.SetBool ("skin 2", false);
		if (num == 3)
			anim.SetBool ("skin 3", true);
		else
			anim.SetBool ("skin 3", false);
		if (num == 4)
			anim.SetBool ("skin 4", true);
		else
			anim.SetBool ("skin 4", false);
		if (num == 5)
			anim.SetBool ("skin 5", true);
		else
			anim.SetBool ("skin 5", false);
		if (num == 6)
			anim.SetBool ("skin 6", true);
		else
			anim.SetBool ("skin 6", false);
		if (num == 7)
			anim.SetBool ("skin 7", true);
		else
			anim.SetBool ("skin 7", false);
	}
	
}
