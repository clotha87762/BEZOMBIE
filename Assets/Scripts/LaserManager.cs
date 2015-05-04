using UnityEngine;
using System.Collections;

public class LaserManager : MonoBehaviour {
	private float cost;
	// Use this for initialization
	public Laser LaserPrefab;
	public Laser laser;
	public AudioClip laserMusic;
	
	
	void Start () {
		cost = 20f;
	}
	
	// Update is called once per frame
	void Update () {
		if (PauseControl.play == false) {
			return;
		}


		if (mpbar.curmp < cost) {
			SpriteRenderer sprite_renderer = GetComponent<SpriteRenderer>();
			sprite_renderer.color = new Color(1f,1f,1f,0.3f);
			
		} else {
			SpriteRenderer sprite_renderer = GetComponent<SpriteRenderer>();
			sprite_renderer.color = new Color(1f,1f,1f,1f);
		}



		
		if (Input.GetKeyDown (KeyCode.Q)) {
			if(mpbar.curmp>=cost){
				GetComponent<AudioSource>().PlayOneShot (laserMusic);
				laser =(Laser) Instantiate(LaserPrefab,new Vector3(0,5.3f,0),Quaternion.identity);
				mpbar.curmp-=cost;
			}
		}
	}
	
	void OnMouseDown(){
		if (PauseControl.play == false) {
			return;
		}
		if(mpbar.curmp>=cost){
			laser =(Laser) Instantiate(LaserPrefab,new Vector3(0,5.3f,0),Quaternion.identity);
			mpbar.curmp-=cost;
		}
	}
}
