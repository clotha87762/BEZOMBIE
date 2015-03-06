using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagicManager : MonoBehaviour {

	// Use this for initialization
	public float interval;
	public float min ,max;
	public float timeCounter;
	public List<MagicBall> balls;
	public MagicBall prefabball;
	public MagicBall mb;
	public float ballSpeed;
	public float maxSpeed;
	void Start () {

		balls = new List<MagicBall> ();
		min = 1f;
		max = 2f;
		ballSpeed = 5f;
		maxSpeed = 15f;
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
			mb =(MagicBall)Instantiate(prefabball,new Vector3(0,5f,0),Quaternion.identity);
			balls.Add(mb);
			mb.setSpeed(ballSpeed);
			if(ballSpeed<=maxSpeed)
			ballSpeed =ballSpeed+ 0.025f;

		}
	
	}
}
