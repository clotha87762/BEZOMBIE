using UnityEngine;
using System.Collections;

public class StarControl : MonoBehaviour {

	// Use this for initialization
	public  bool isStar;
	public float starTime;
	public float endTime;
	public int killTime;
	public AudioClip starClip;


	void Start () {
		starTime = 0;
		isStar = false;
		endTime = 0;
	

	}
	
	// Update is called once per frame
	void Update () {

		if (isStar) {
			starTime+=Time.deltaTime;
			endTime+=Time.deltaTime;
			if(starTime>=0.5){
				GetComponent<AudioSource>().PlayOneShot(starClip);
				starTime = 0;
				foreach( GameObject g in GameObject.FindGameObjectsWithTag("Human")){
					
					if(g.GetComponent<human>().dieflag==false){
						g.GetComponent<human>().OnDie(true);
					}			
				}
			}

			if(endTime>=3.5){
			
				isStar=false;
				starTime=0;
				endTime=0;
			}

		}
	
	}
}
