using UnityEngine;
using System.Collections;

public class Help : MonoBehaviour {
	private bool onon;
	public GameObject h;
	public GameObject s;
	public GameObject b;
	private bool TimeToEnter;
	private bool TimeToLeave;
	private float movespeed;
	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector2 (5.82f,-0.37f);
		TimeToLeave = false;
		TimeToEnter = false;
		movespeed = 0;
		onon = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (HelpButton.OnHelp == true&& onon==false) {
			h.GetComponent<CircleCollider2D> ().enabled = false;
			s.GetComponent<CircleCollider2D> ().enabled = false;
			b.GetComponent<CircleCollider2D> ().enabled = false;
			TimeToEnter = true;
			onon=true;
			//HelpButton.OnHelp = false;
		}
		if (transform.position.x != 0 && TimeToEnter==true) {
			if(movespeed<0)
				movespeed=0.1f;
			else if(movespeed>transform.position.x){
				transform.position= new Vector2(0,-0.37f);
				movespeed=0;
			}
			else if(transform.position.x>=2.91f){
				movespeed+=Time.deltaTime;
			}
			else{
				movespeed-=Time.deltaTime;
			}
			gameObject.transform.Translate(-1*movespeed,0,0);
		}
		else if (transform.position.x == 0&&TimeToEnter==true) {
			TimeToEnter=false;
		}
		else if (TimeToLeave==true) {
			if(transform.position.x<-5.32f){
				TimeToLeave=false;
				gameObject.transform.position = new Vector2 (5.82f,-0.37f);
				HelpButton.OnHelp = false;
				movespeed=0f;
				onon=false;
				h.GetComponent<CircleCollider2D> ().enabled = true;
				s.GetComponent<CircleCollider2D> ().enabled = true;
				b.GetComponent<CircleCollider2D> ().enabled = true;
			}
			else if(movespeed>0.4f){
				movespeed = 0.4f;
			}
			else{
				movespeed+=Time.deltaTime;
			}
			
			gameObject.transform.Translate(-1*movespeed,0,0);
		}
	}
	void OnMouseDown(){
		if(transform.position.x==0f&&!TimeToLeave==true)
			TimeToLeave = true;
	}
}
