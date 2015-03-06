using UnityEngine;
using System.Collections;

public class FogManager : MonoBehaviour {
	private float cost;
	public GameObject p1;
	public GameObject p2;
	public ParticleSystem ps1;
	public ParticleSystem ps2;
	public bool isTriggered;
	public float timer;
	public float triggerInterval;
	public Dizzy dizzprefab;
	public Dizzy dizz;
	public AudioClip fogMusic;
	
	void Start () {
		cost = 40f;
		isTriggered = false;
		triggerInterval = 5f;
		ps1 = p1.GetComponent<ParticleSystem> ();
		ps2 = p2.GetComponent<ParticleSystem> ();
		timer = 0;
	}
	void Update () {
		
		if (PauseControl.play == false) {
			return;
		}


		if (mpbar.curmp < 30) {
			SpriteRenderer sprite_renderer = GetComponent<SpriteRenderer>();
			sprite_renderer.color = new Color(1f,1f,1f,0.3f);
			
		} else {
			SpriteRenderer sprite_renderer = GetComponent<SpriteRenderer>();
			sprite_renderer.color = new Color(1f,1f,1f,1f);
		}



		
		if (Input.GetKeyDown (KeyCode.T)) {
			if(mpbar.curmp>=cost){
				isTriggered = true;
				ps1.Play ();
				ps2.Play ();
				audio.PlayOneShot(fogMusic);
				mpbar.curmp-=cost;
			}
		}
		if (isTriggered) {
			timer+=Time.deltaTime;
			
			Collider2D[] hits = Physics2D.OverlapCircleAll(new Vector2(0,0),2.5f);
			int i;
			i=0;
			while (i < hits.Length) {
				
				if(hits[i].tag=="Human"){
					human h = hits[i].GetComponent<human>();
					if(!h.stopflag&&!h.dieflag)
						h.OnSlow(1.25f*human.maxhumanspeed/100);
					
					if(h.haveDizzy==false){
						dizz = (Dizzy)Instantiate (dizzprefab, new Vector2 (h.transform.position.x,h.transform.position.y+2f*h.scaleIndex), Quaternion.identity);
						dizz.geth(h);
						h.haveDizzy = true;
						dizz.timeout = timer;
					}
				}
				i+=1;
			}
			
			if(timer>=triggerInterval){
				ps1.Stop();
				ps2.Stop();
				audio.Stop ();
				isTriggered=false;
				timer=0;
			}
		}
	}
	
	void OnMouseDown(){
		if (PauseControl.play == false) {
			return;
		}
		
		if(mpbar.curmp>=cost){
			isTriggered = true;
			ps1.Play ();
			ps2.Play ();
			audio.PlayOneShot(fogMusic);
			mpbar.curmp-=cost;
		}
		
	}
	
	
	
	
}
