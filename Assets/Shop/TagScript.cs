using UnityEngine;
using System.Collections;

public class TagScript : MonoBehaviour {

	// Use this for initialization

	public Tag2Script tag2;
	public GameObject shopitem1 ,shopitem2;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		//tag2.gameObject.SetActive (true);
		shopitem2.gameObject.SetActive (true);
		shopitem1.gameObject.SetActive (false);
		//gameObject.SetActive (false);
	}
}
