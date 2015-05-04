using UnityEngine;
using System.Collections;

public class SkyBomb : MonoBehaviour {

	// Use this for initialization
	public float endX,endY;
	public float startX, startY;
	public float speed;
	public bool move;
	public float timer;
	public AudioClip fireMusic;
	Animator anim ;
	Animation burn;


	void Start () {
		speed = 5;
		gameObject.GetComponent<CircleCollider2D> ().enabled = false;

		move = true;
		timer = 0;
		anim = GetComponent<Animator>();
		anim.enabled = false;
		burn = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
		void Update () {




		if (PauseControl.play == false) {
			return;
		}


		if(endY-transform.position.y<0.4f)
			gameObject.GetComponent<CircleCollider2D> ().enabled = true;

		

		if (move) {
			transform.Translate (new Vector3 (speed * Time.deltaTime * -1, speed * Time.deltaTime * -1, 0));
			float temp = -(endY - 5) / 10;
			transform.localScale = new Vector3 (temp * 2 + 0.5f, temp * 2 + 0.5f, temp * 2 + 0.5f);
			if (transform.position.x < endX && transform.position.y < endY){
				Collider2D[] hithumans =Physics2D.OverlapCircleAll(new Vector2(transform.position.x,transform.position.y),1f*temp);
				GetComponent<AudioSource>().PlayOneShot(fireMusic);
				int i=0;

				while (i < hithumans.Length) {

					if( hithumans[i].tag=="Human"){

					human h = hithumans[i].GetComponent<human>();
					h.OnDie(false);
					
					}
					i+=1;
				}
				transform.localScale = new Vector3 (temp * 3.5f + 0.5f, temp * 3.5f + 0.5f, temp * 3.5f + 0.5f);

				anim.enabled = true;
				//gameObject.GetComponent<CircleCollider2D> ().enabled = false;
				move = false;

				anim.SetBool("Burn",true);

			}
		} else if (!move) {
			timer +=Time.deltaTime;
			if(timer>=1.8f)
				Destroy(gameObject);

		}
	}

	void onTriggerEnter(Collider2D coll){

		if (coll.gameObject.tag == "human") {

		}

	}


	public void setDes(float x, float y){
		endX = x;
		endY = y;
		startX = endX + 3;
		startY = endY + 3;
	}
}
