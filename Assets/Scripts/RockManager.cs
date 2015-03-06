using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RockManager : MonoBehaviour {
	private float cost;
	
	private int RockCount;
	private float Rocktime;
	private float Rocktimeinterval;
	
	public float interval;
	public float min ,max;
	public float timeCounter;
	public List<Rock> rocks;
	public Rock prefabrock;
	public Rock rock;
	public float rockSpeed;
	public float maxSpeed;
	public float timerForSkill;
	public float intervalForSkill=0.5f;
	public int j;
	void Start () {
		cost = 30f;
		rocks = new List<Rock> ();
		min = 4f;
		max = 8f;
		rockSpeed = 5f;
		maxSpeed = 15f;
		timeCounter = 0;
		//intervalForSkill = 0.25f;
		//timerForSkill=intervalForSkill;
		Rocktime = 0f;
		Rocktimeinterval = 0.25f;
		interval = Random.Range (min, max);
		
		RockCount = 0;
	}
	
	
	
	// Update is called once per frame
	void Update () {
		
		if (PauseControl.play == false) {
			return;
		}


		if (mpbar.curmp < cost) {
			SpriteRenderer sprite_renderer = GetComponent<SpriteRenderer>();
			sprite_renderer.color = new Color(1f,1f,1f,0.3f);
			
		} else {
			SpriteRenderer sprite_renderer = GetComponent<SpriteRenderer>();
			sprite_renderer.color = new Color(1f,1f,1f,1f);
		}



		
		if (Input.GetKeyDown (KeyCode.E)) {
			if(mpbar.curmp>=cost){
				j = 0;
				//StartCoroutine ("go");
				Rocktime=Rocktimeinterval;
				RockCount+=5;
				mpbar.curmp-=cost;
			}
		}
		
		timeCounter += Time.deltaTime;
		if (timeCounter > interval) {
			
			timeCounter = 0;
			interval = Random.Range (min, max);
			rock =(Rock)Instantiate(prefabrock,new Vector3(0,5f,0),Quaternion.identity);
			rocks.Add(rock);
			rock.setSpeed(rockSpeed);
			if(rockSpeed<=maxSpeed)
				rockSpeed =rockSpeed+ 0.1f;
			
		}
		if (Rocktime < Rocktimeinterval)
			Rocktime += Time.deltaTime;
		if (RockCount > 0) {
			if(Rocktime>=Rocktimeinterval){
				rock =(Rock)Instantiate(prefabrock,new Vector3(0,5f,0),Quaternion.identity);
				rocks.Add (rock);
				rock.setSpeed (rockSpeed);
				RockCount-=1;
				Rocktime=0;
			}
		}
	}
	
	void OnMouseDown(){
		
		if (PauseControl.play == false) {
			return;
		}
		
		if(mpbar.curmp>=cost){
			j = 0;
			//StartCoroutine ("go");
			Rocktime=Rocktimeinterval;
			RockCount+=5;
			mpbar.curmp-=cost;
		}
		
		
	}
	/*
	IEnumerator go(){

		while (j<=5) {

			if (PauseControl.play == false) {
				continue;
			}


			rock = (Rock)Instantiate (prefabrock, new Vector3 (0, 5f, 0), Quaternion.identity);
			rocks.Add (rock);
			rock.setSpeed (rockSpeed);
			
			j++;
			yield return new WaitForSeconds (intervalForSkill);
		}	
	}

*/
	
	
}
