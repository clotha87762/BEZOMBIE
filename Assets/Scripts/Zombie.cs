using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public float mSpeed = 10f;
	public bool bumptoHuman , bumptoMagic;
	// Use this for initialization
	public LayerMask magic;
	public LayerMask human;
//	public ScoreBoard scoreBoard ;
	public float v=0;
	public mpbar mp;
	Vector3 set;
	public float curMinSpeed;
	public Vector2 tempVel;
	public AudioClip music;
	public int tempSpeed;
	public int runningSpeed;


	void Start () {
		
		Animator anim = GetComponent<Animator>();
		anim.speed=1;
		curMinSpeed =1;
	}
	
	public void ChangeSpeed(float newspeed){


		Animator anim = GetComponent<Animator>();
		if (newspeed <= anim.speed)
			return;

		anim.speed=newspeed;
		curMinSpeed = newspeed;
	}

	public void PlusSpeed(float delta){
		Animator anim = GetComponent<Animator>();
		if(anim.speed+delta>=curMinSpeed)
		anim.speed= anim.speed + delta;

	}


	void OnTriggerEnter2D(Collider2D coll){

		if (PauseControl.play == false) {
			return;
		}

		if(coll.gameObject.tag=="human"){
		
		}
		else if(coll.gameObject.tag=="MagicBall"){
			/*((Num0)GameObject.Find("Num0")).getScore = true;
			Debug.Log("b!!");*/
			GetComponent<AudioSource>().PlayOneShot (music);
			//Debug.Log("b!!");
			mp.AdjMana(10f);
		}

	}


	// Update is called once per frame
	void FixedUpdate () {

		//bumptoHuman = Physics2D.OverlapCircle(transform.position.x,
		/*
		if (PauseControl.play == true) {

			if(rigidbody2D.IsSleeping()){
				rigidbody2D.WakeUp();
				rigidbody2D.velocity = tempVel;
			}
			tempVel= rigidbody2D.velocity;
		}*/


		if (PauseControl.play == false) {

			GetComponent<Rigidbody2D>().Sleep();
			return;
		}




		v = Input.GetAxis ("Horizontal") ;
		
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(v*mSpeed,GetComponent<Rigidbody2D>().velocity.y);
		}

		if (transform.position.x > 2.2f){
			set= new Vector3(2.2f,GetComponent<Rigidbody2D>().position.y,0);
			transform.position=set;
		}
		else if(transform.position.x<-2.2f){
			set= new Vector3(-2.2f,GetComponent<Rigidbody2D>().position.y,0);
			transform.position=set;
		}

	}
}
