using UnityEngine;
using System.Collections;

public class MagicBall : MonoBehaviour {

	// Use this for initialization
	public float endX;
	public float ratioY;
	public float speed;


	public GameObject mp;
	void Start () {
		transform.position = new Vector3 (0,5f,0);
		endX = Random.Range (-2.2f, 2.2f);
		ratioY = calY (endX);

		//smooth = 1.0f;
	}
	public void setSpeed(float f){
		speed = f;
	}

	void OnTriggerEnter2D(Collider2D coll){

		if (PauseControl.play == false) {
			return;
		}


		if (coll.gameObject.tag == "Zombie") {

			Destroy (gameObject);
		}
		else if (coll.gameObject.tag == "Human") {

		}
	}


	// Update is called once per frame
	void FixedUpdate () {
		if (PauseControl.play == false) {
			return;
		}


		float temp = -(transform.position.y - 5) / 10;
		transform.Translate (new Vector3 (endX/9.0f*speed*(temp+1),-speed*(temp+1), 0)*Time.deltaTime);

		transform.localScale = new Vector3(temp*0.5f,temp*0.5f,temp*0.5f);
		if (transform.position.y < -3.8)
			Destroy (gameObject);

	}


		                                  
	 float calY(float x){
		float temp;
		temp = 885 / endX;
		return temp;
	 }



}
