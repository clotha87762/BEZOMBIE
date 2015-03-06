using UnityEngine;
using System.Collections;

public class EarthquakeManager : MonoBehaviour {
	private float cost;
	public Earthquake maincamera;
	public human script;
	public GameObject[] humans;
	// Use this for initialization
	void Start () {
		cost = 35f;
	}
	
	// Update is called once per frame
	void Update () {
		if (PauseControl.play == false) {
			return;
		}
		

		if (mpbar.curmp < 25) {
			SpriteRenderer sprite_renderer = GetComponent<SpriteRenderer>();
			sprite_renderer.color = new Color(1f,1f,1f,0.3f);
			
		} else {
			SpriteRenderer sprite_renderer = GetComponent<SpriteRenderer>();
			sprite_renderer.color = new Color(1f,1f,1f,1f);
		}


		if (Input.GetKeyDown (KeyCode.R)) {
			if(mpbar.curmp>=cost){

				maincamera.quake (5);
				humans=GameObject.FindGameObjectsWithTag ("Human");
				int i;
				for (i=0; i<humans.Length; i++) {
					script = humans[i].GetComponent<human>();
					script.OnStop(2f);
					float k =Random.Range(0,1.999f);
					if(k<1)
						script.Falldown(2f,true);
					else if(k>=1)
						script.Falldown(2f,false);
				}
				mpbar.curmp-=cost;
			}
		}
	}
	void OnMouseDown(){
		
		if (PauseControl.play == false) {
			return;
		}
		
		if(mpbar.curmp>=cost){
			maincamera.quake (5);
			humans=GameObject.FindGameObjectsWithTag ("Human");
			int i;
			for (i=0; i<humans.Length; i++) {
				script = humans[i].GetComponent<human>();
				script.OnStop(2f);
				float k =Random.Range(0,1.999f);
				if(k<1)
					script.Falldown(2f,true);
				else if(k>=1)
					script.Falldown(2f,false);
			}
			mpbar.curmp-=cost;
		}
		
	}
}
