using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	// Use this for initialization
	public float pivotx,pivoty;
	public GameObject zombie;
	public float degree;
	public float timer;

	void Start () {
		pivotx = 0;
		pivoty = 5.1f;
		timer = 0;
		zombie = GameObject.FindGameObjectWithTag ("Zombie");
		setRotate (zombie.transform.position.x);
	}

	public void setRotate(float x){

		degree = Mathf.Atan2 (0 - x, 5.2f)*0.7f;
		transform.Rotate (-Vector3.forward * degree * 180 / Mathf.PI);

	}

	void onTriggerEnter(Collider2D coll){
		
		if (PauseControl.play == false) {
			return;
		}

		if (coll.gameObject.tag == "human") {
			
		}
		
	}

	// Update is called once per frame
	void Update () {

		if (PauseControl.play == false) {
			return;
		}

		timer += Time.deltaTime;
		transform.localScale = new Vector3 (timer*8,1.896f,0);
		if (timer >= 0.25f) {
			Destroy (gameObject);
		}

	}




}
