using UnityEngine;
using System.Collections;



public class human : MonoBehaviour {
	static public  float maxhumanspeed;
	public  float highestspeed=7; 
	public float humanspeed;
	private float ug, mg;
	private float xspeed;
	private float stoptimecounter,maxstoptime;
	public bool stopflag;
	public float falltimecounter,maxfalltime;
	public bool fallflag;
	public GameObject qq ;
	public bool dieflag; 
	public background bb;
	public Zombie zz;
	public float scaleIndex;
	private float XmoveIndex;
	private float XmoveTime;
	private float Xmove,Xmovespeed;
	private float xx;
	public bool cheatTime;
	public float cheatTimer;
	//--drop
	private float dropSpeed;
	private bool dropstate1,dropstate2;
	public bool haveDizzy;
	//--blood
	//public BloodGManager bloodgmanager;
	public GameObject bloodgmanagerr;
	private bool bloodGflag;
	public GameObject gameover;

	public AudioClip fallMusic;
	public AudioClip dieMusic;
	bool playflag=true;
	float alpha;
	void Start(){

		gameover = GameObject.FindGameObjectWithTag ("Pause");

		alpha = 0;

		cheatTime = true;
		cheatTimer = 0;
		humanspeed = 0;
		stopflag = false;
		fallflag = false;
		dieflag = false; 
		
		XmoveIndex = Random.Range (0.5f,1f);
		XmoveTime = 0;
		Xmove = 0;
		Xmovespeed = 0;
		xx = 4f/10f;
		haveDizzy = false;
		//--
		
		dropSpeed = 1f;
		dropstate1 = true;
		dropstate2= true;
		//--
		bloodgmanagerr = GameObject.Find("BloodGManager");
		bloodGflag = false;

	}
	
	public void setSpeed(float s){
		
		maxhumanspeed = s;
		if (maxhumanspeed >= highestspeed)
			maxhumanspeed = highestspeed;
		qq = GameObject.FindGameObjectWithTag ("Background");
		bb =qq.GetComponent<background>();
		bb.ChangeSpeed((maxhumanspeed/highestspeed)*2.5f+0.2f);
		qq = GameObject.FindGameObjectWithTag ("Zombie");
		zz = qq.GetComponent<Zombie>();
		zz.ChangeSpeed((maxhumanspeed/highestspeed)*2.5f+0.2f);
	}
	
	void FixedUpdate () {
		

		if (PauseControl.play == false) {
			return;
		}


		if (cheatTime) {

			alpha = (alpha +0.1f)%1f;
			GetComponent<Renderer>().material.color = new Color(1f,1f,1f,alpha);

		}



		if (dropstate1 == true) {
			gameObject.transform.localScale = new Vector2 (0.7459827f, 0.6816657f);
			dropSpeed+=Time.deltaTime;
			if (gameObject.transform.position.y - dropSpeed < 0) {
				gameObject.transform.Translate (0, -1f*gameObject.transform.position.y,0);
				Animator anim = GetComponent<Animator>();
				anim.SetBool("show",true);
				dropstate1 = false;
				dropstate2 = true;
				dropSpeed =0.2f;
				
			} 
			else {
				gameObject.transform.Translate (0, -1f*dropSpeed,0);
			}
		}
		else if (dropstate2 == true) {
			dropSpeed-=Time.deltaTime;
			if (gameObject.transform.position.y + dropSpeed < 0.1f) {
				gameObject.transform.Translate (0, -1f*gameObject.transform.position.y+0.2f,0);
				dropstate2 = false;
			} 
			else {
				gameObject.transform.Translate (0, dropSpeed,0);
			}
		}
		
		//--
		cheatTimer += Time.deltaTime;
		if (cheatTimer >= 1f) {
			cheatTime = false;
			GetComponent<Renderer>().material.color = new Color(1f,1f,1f,1f);
		}
		
		if (transform.position.y > 4 && cheatTime==false) {
			
			ManManager.numberOfHuman-=1;

			
			if (ManManager.humanSpeed < 7)
				ManManager.humanSpeed += 0.02f;

			Debug.Log("why??");
			gameover.BroadcastMessage("GameOver");
			
			Destroy (gameObject);
			
			
		}
		else if(transform.position.y < -3.3f){
			if(playflag){GetComponent<AudioSource>().PlayOneShot(dieMusic);playflag=false;}

		}
		else if(transform.position.y < -3.5f){
			if (ManManager.humanSpeed  < 7)
				ManManager.humanSpeed  += 0.02f;

			Destroy (gameObject);
		}
		
		
		
		ug = (float)(gameObject.transform.position.y*-1f+4f);
		mg = (float)(gameObject.transform.position.x);
		
		xspeed = -mg/ug;
		if (humanspeed < maxhumanspeed && stopflag == false && dieflag == false) {
			humanspeed += maxhumanspeed / 100;
		}
		transform.Translate(xspeed*humanspeed*Time.deltaTime+Xmovespeed*Time.deltaTime,humanspeed*Time.deltaTime,0);
		
		scaleIndex = -(transform.position.y - 5) / 10;
		
		if (dropstate1 == false) {
			gameObject.transform.localScale = new Vector2 (scaleIndex * 0.5f, scaleIndex * 0.5f);
		}
		
		//gameObject.transform.localScale = new Vector2 (scaleIndex * 0.5f, scaleIndex * 0.5f);
		
		if (transform.position.y < -2.5f) {
			if(bloodGflag==false){
				bloodGflag = true;
				bloodgmanagerr.SendMessage("someoneDie",gameObject.transform.position.x);
			}
			//bloodgmanager.someoneDie(gameObject.transform.position.x);
			OnDie (true);
		}
		
		XmoveTime += Time.deltaTime;
		if (XmoveTime > XmoveIndex) {
			XmoveTime=0;
			XmoveIndex = Random.Range(0.3f,0.5f);
			Xmove = Random.Range(-0.4f,0.4f);
		Xmove+=(Xmove>0)?1f:-1;
			if((gameObject.transform.position.x+Xmove)/(gameObject.transform.position.y*-1f+4f)>xx||(gameObject.transform.position.x+Xmove)/(gameObject.transform.position.y*-1f+4f)<-1*xx){
			Xmove=(Xmove>0)?(gameObject.transform.position.y*-1f+4f)*xx-gameObject.transform.position.x:(gameObject.transform.position.y*-1f+4f)*-1f*(xx)-gameObject.transform.position.x;
			}
			Xmovespeed = (Xmove>0)?2f:-2f;
		}
		if (Xmove != 0) {
			if(stopflag==true || dieflag==true){
				Xmovespeed=0;
				Xmove=0;
			}
			else
				Xmove-=Xmovespeed*Time.deltaTime;
			if(Xmovespeed*Xmove<0)
				Xmove=0;
		}
		if (Xmove == 0) {
			Xmovespeed = 0;
		}
		
		
	}
	
	void OnTriggerEnter2D(Collider2D coll) {


		if (PauseControl.play == false) {
			return;
		}



		if (coll.gameObject.tag == "Zombie"){
			OnDie(false);
		}
		
		
		if (coll.gameObject.tag == "SkyBomb") {
			SkyBomb temp = (SkyBomb)coll.GetComponent<SkyBomb>();
			if(!temp.move){
				OnDie(false);
			}
		}
		
		if(coll.gameObject.tag=="Rock"){
			
			OnStop(1);
			Falldown(1,true);
		}
		
		
		if (coll.gameObject.tag == "Laser") {
			
			if(transform.position.x>=0){
				OnDie (false);
			}
			else{
				OnDie (true);
			}
			
		}
	}
	
	void Update(){

		if (PauseControl.play == false) {
			return;
		}




		/*
		if (Input.GetKey (KeyCode.I)){
			humanspeed =0;
			gameObject.transform.position = new Vector2(0, 0);
			if (maxhumanspeed >= highestspeed)
				maxhumanspeed = highestspeed;
			qq = GameObject.FindGameObjectWithTag ("Background");
			bb =qq.GetComponent<background>();
			bb.ChangeSpeed((maxhumanspeed/highestspeed)*2.5f+0.2f);
			qq = GameObject.FindGameObjectWithTag ("Zombie");
			zz = qq.GetComponent<Zombie>();
			zz.ChangeSpeed((maxhumanspeed/highestspeed)*2.5f+0.2f);
		}
		if (Input.GetKey (KeyCode.U)){
			OnSlow(0.5f);
		}
		if (Input.GetKey (KeyCode.Y)){
			OnDie(true);
		}
		if (Input.GetKey (KeyCode.O)){
			OnStop(1);
			Falldown(1,true);
		}
		*/
		if (stopflag == true) {
			stoptimecounter += Time.deltaTime;
			if(stoptimecounter>=maxstoptime)
				OnStop(maxstoptime);
		}
		
		if (fallflag == true) {
			falltimecounter += Time.deltaTime;
			if(falltimecounter>=maxfalltime)
				Falldown(maxfalltime,true);
		}
	}
	
	/*void OnInjured(){
	
	}*/
	
	public void OnSlow(float slowdown){
		if (cheatTime)
			return;
		humanspeed -= slowdown;
	}
	
	public void OnStop(float stoplength){
		/*if (cheatTime)
			return;*/
		if (stopflag == false || stoptimecounter<maxstoptime) {
			humanspeed = -1f*maxhumanspeed;
			maxstoptime=stoplength/maxhumanspeed;
			stopflag = true;
			stoptimecounter = 0;
			
		} 
		else if(stoptimecounter>=maxstoptime && dieflag ==false){
			stopflag = false;
			humanspeed = 0f;
			stoptimecounter = 0;
			maxstoptime = 0;
		}
	}
	
	public void Falldown(float falllegnth,bool rightside){
		
		if (cheatTime)
			return;
		GetComponent<AudioSource>().PlayOneShot (fallMusic);
		Animator anim = GetComponent<Animator>();
		
		if (rightside == true) {

			if (fallflag == false || falltimecounter<maxfalltime) {
				anim.SetBool ("falldownR", true);
				maxfalltime=falllegnth/maxhumanspeed;
				fallflag = true;
				falltimecounter = 0;
				
			} 
			else if(falltimecounter>=maxfalltime){
				fallflag = false;
				anim.SetBool ("falldown", false);
				anim.SetBool ("falldownR", false);
				falltimecounter = 0;
				maxfalltime = 0;
			}
		}
		else{
			if (fallflag == false || falltimecounter<maxfalltime) {
				anim.SetBool ("falldown", true);
				maxfalltime=falllegnth/maxhumanspeed;
				fallflag = true;
				falltimecounter = 0;
				
			} 
			else if(falltimecounter>=maxfalltime){
				fallflag = false;
				anim.SetBool ("falldown", false);
				anim.SetBool ("falldownR", false);
				falltimecounter = 0;
				maxfalltime = 0;
			}
		}
	}
	public void OnDie(bool right){
		
		if (cheatTime)
			return;
		
		if (dieflag)
			return;

		GetComponent<AudioSource>().PlayOneShot (fallMusic);

		ManManager.numberOfHuman -= 1;
		ManManager.humanAlreadyKilled+=1;
		dieflag = true;
		Animator anim = GetComponent<Animator>();
		humanspeed = -1f*maxhumanspeed;
		if(PushButton.slowSpeed>=0.02f)
		PushButton.slowSpeed -= 0.0005f;
		if(right == true)
			anim.SetBool ("dieR", true);
		else
			anim.SetBool ("die", true);
		
		Num0.getScore += 1;
	}
}
