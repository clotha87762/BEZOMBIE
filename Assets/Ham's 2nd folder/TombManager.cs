using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TombManager : MonoBehaviour {
	
	// Use this for initialization
	public float interval;
	public float min ,max;
	public float timeCounter;
	public List<Tomb> tombs;
	public Tomb prefabtomb;
	public Tomb tb;
	public float tombSpeed;
	//public human hh;
	void Start () {
		
		tombs = new List<Tomb> ();
		min = 0.1f;
		max = 0.2f;
		tombSpeed = 5f;
		timeCounter = 0;
		interval = Random.Range (min, max);
	}
	
	
	
	// Update is called once per frame
	void Update () {
		if (PauseControl.play == false) {
			return;
		}

		timeCounter += Time.deltaTime;
		if (timeCounter > interval) {
			
			timeCounter = 0;
			interval = Random.Range (min, max);
			tb =(Tomb)Instantiate(prefabtomb,new Vector3(0,5.4f,0),Quaternion.identity);
			tb.setSpeed(tombSpeed);
			float tempend = Random.Range(3.5f,7f);
			tb.setendX(tempend);
			tb.setNumber();
			float OneMore = Random.Range(0f,1f);
			if(OneMore>0.8f){
				tb =(Tomb)Instantiate(prefabtomb,new Vector3(0,5.4f,0),Quaternion.identity);
				tb.setSpeed(tombSpeed);
				tb.setendX(tempend+1f);
				tb.setNumber();
			}
			tombSpeed+=0.001f;
		}
		
	}
}
