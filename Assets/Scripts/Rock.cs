using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

	// Use this for initialization
	public float endX;
	public float speed;

	void Start () {
	
		transform.position = new Vector3 (0,5f,0);

		endX = Random.Range (-2.2f, 2.2f);
		int temp = (int)Random.Range (0, 3.999f);
		if (temp == 0) {
			gameObject.GetComponent<SpriteRenderer>().sprite= Resources.Load<Sprite>("rock");

		} else if (temp == 1) {
			gameObject.GetComponent<SpriteRenderer>().sprite= Resources.Load<Sprite>("rock1");
		} else if (temp == 2) {
			gameObject.GetComponent<SpriteRenderer>().sprite= Resources.Load<Sprite>("rock2");
		} else if (temp == 3) {
			gameObject.GetComponent<SpriteRenderer>().sprite= Resources.Load<Sprite>("rock3");
		}

	}
	
	public void setSpeed(float f){
		speed = f;
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

	void OnTriggerEnter2D(Collider2D coll){


	}
}
