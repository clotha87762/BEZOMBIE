using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CoinManager : MonoBehaviour {
	public float interval;
	public float min ,max;
	public float timeCounter;
	public List<Coin> coins;
	public Coin prefabcoin;
	public Coin coin;
	public float coinSpeed;
	public float maxSpeed;
	void Start () {
		
		coins = new List<Coin> ();
		min = 5f;
		max = 10f;
		coinSpeed = 5f;
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
			coin =(Coin)Instantiate(prefabcoin,new Vector3(0,5f,0),Quaternion.identity);
			coins.Add(coin);
			coin.setSpeed(coinSpeed);
			if(coinSpeed<=maxSpeed)
				coinSpeed =coinSpeed+ 0.05f;
			if(min>=2)
			min-=0.1f;
			if(max>=4)
			max-=0.2f;

			interval = Random.Range (min, max);

		}
		
	}
}
