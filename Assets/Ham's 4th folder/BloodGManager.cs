using UnityEngine;
using System.Collections;

public class BloodGManager : MonoBehaviour {
	public BloodG bloodgprefab;
	private BloodG bloodg;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void someoneDie(float local){
		bloodg =(BloodG)Instantiate(bloodgprefab,new Vector3(local,-2.8f,0),Quaternion.identity);
	}
}
