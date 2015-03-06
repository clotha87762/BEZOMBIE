using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ManManager : MonoBehaviour {

	// Use this for initialization
	public human manPrefab;
	public human man;
	public List<human> men;
	static public float numberOfHuman;
	static public float humanSpeed;
	static public float humanAlreadyKilled;
	public float timer;
	public float interval;

	void Start () {
		numberOfHuman = 0;
		men = new List<human> ();
		humanSpeed = 1f;
		humanAlreadyKilled = 0;
		timer = 0;
		interval = 2f;
	}
	
	// Update is called once per frame
	void Update () {

		if (PauseControl.play == false) {
			return;
		}


		timer += Time.deltaTime;

		/*if (humanAlreadyKilled <= 5) {
			if (numberOfHuman <= 0) {
				numberOfHuman = 0;
				Debug.Log ("noone~~");
				numberOfHuman += 1;
				man = (human)Instantiate (manPrefab, new Vector2 (Random.Range (-1.9f, 1.9f), 0), Quaternion.identity);
				man.setSpeed (humanSpeed);
				men.Add (man);
				if (humanSpeed < 7)
					humanSpeed += 0.2f;

			}
		}*/

		float temp = humanAlreadyKilled / 15;
		if (temp >= 6)
			temp = 6;

		if (numberOfHuman <= temp) {

			if(numberOfHuman<=0){
				numberOfHuman = 0;
				numberOfHuman += 1;
				man = (human)Instantiate (manPrefab, new Vector2 (Random.Range (-1.9f, 1.9f), 8), Quaternion.identity);
				man.setSpeed (humanSpeed);
				men.Add (man);
			}
			else if(timer>=interval){
				numberOfHuman += 1;
				man = (human)Instantiate (manPrefab, new Vector2 (Random.Range (-1.9f, 1.9f), 8), Quaternion.identity);
				man.setSpeed (humanSpeed);
				men.Add (man);
				timer = 0;
			}



		}


		
		





	}

	void OnDestroy(){
		ManManager.numberOfHuman = 0;
		ManManager.humanAlreadyKilled = 0;
	}

}
