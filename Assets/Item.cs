﻿using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	// Use this for initialization
	public enum Which {none ,MPPotion, Star,MPHealer}

	public Which item =Which.none;
	public bool enable=false;
	public static int limit=3;
	public ManManager manManager;
	public StarControl sc;
	public AudioClip mppotion ;
	public AudioClip mphealer ;

	void Start () {


		if (Load.MPPotion > 0) {
			Debug.Log("mppotion");
			item = Which.MPPotion;
			enable = true;
			Load.MPPotion-=1;
		} 
		else if (Load.MPHealer > 0) {  
			item = Which.MPHealer;
			enable = true;
			Load.MPHealer-=1;
		}
		else if(Load.Star > 0){
			item = Which.Star;
			enable = true;
			Load.Star-=1;
		}

		if (item == Which.MPPotion) {
			GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("poison");
		} else if (item == Which.Star) {
			GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("star");
		} else if (item == Which.MPHealer) {
			GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("healer");
		}

	}
	
	// Update is called once per frame
	void Update () {




	}

	void OnMouseDown(){

		if (enable == false || PauseControl.play ==false)
			return;

		if (item == Which.MPPotion) {
			mpbar.curmp = 100;
				enable=false;
			audio.PlayOneShot(mppotion);
			GetComponent<SpriteRenderer>().enabled=false;
			//gameObject.SetActive(false);

		} else if (item == Which.Star) {
			enable = false;

			foreach( GameObject g in GameObject.FindGameObjectsWithTag("Human")){
				g.GetComponent<human>().cheatTime=false;
				g.GetComponent<human>().OnDie(true);
			}
			sc.isStar=true;
			sc.GetComponent<Animator>().SetTrigger("trigger2");
			gameObject.SetActive(false);
		}
		else if(item == Which.MPHealer){
			mpbar.autoHeal=true;
			enable = false;

			audio.PlayOneShot(mphealer);
			GetComponent<SpriteRenderer>().enabled=false;
		}

	}

	public void destroyCheck(){
		if (enable == true && item == Which.MPHealer) {
			Load.MPHealer+=1;
		} else if (enable == true && item == Which.MPPotion) {
			Load.MPPotion+=1;
		} else if (enable == true && item == Which.Star) {
			Load.Star+=1;
		}

	}
}
;