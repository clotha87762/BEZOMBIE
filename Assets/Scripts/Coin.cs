using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	
	public float endX;
	public float ratioY;
	public float speed;
	public ShowMoney money;
	public GameObject mp;

	void Start () {
		/*if (PauseControl.play == false) {
			Destroy (gameObject);
		}*/
		transform.localScale = new Vector3(0,0,0);
		transform.position = new Vector3 (0,5f,0);
		endX = Random.Range (-2.2f, 2.2f);
		
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
			money.getCoin();
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
		
		transform.localScale = new Vector3(temp,temp,temp);
		if (transform.position.y < -3.8)
			Destroy (gameObject);
		
	}
}
