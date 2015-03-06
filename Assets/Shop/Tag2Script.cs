using UnityEngine;
using System.Collections;

public class Tag2Script : MonoBehaviour {

	// Use this for initialization
	public TagScript tag1;
	public GameObject shopitem1 ,shopitem2;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		//tag1.gameObject.SetActive (true);
		shopitem1.gameObject.SetActive (true);
		shopitem2.gameObject.SetActive (false);
		//gameObject.SetActive (false);
	}
}
