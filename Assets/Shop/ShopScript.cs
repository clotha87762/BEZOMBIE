using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ShopScript : MonoBehaviour {
	private bool onon;
	public GameObject h;
	public GameObject s;
	public GameObject b;
	public bool TimeToEnter;
	public bool TimeToLeave;
	public float movespeed;
	public Text myMoney;
	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector2 (0,10f);
		TimeToLeave = false;
		TimeToEnter = false;
		movespeed = 0;
		onon = false;

		
	}
	
	// Update is called once per frame
	void Update () {
	

		if (BuyButton.onBuy == true&& onon==false) {
			h.GetComponent<CircleCollider2D> ().enabled = false;
			s.GetComponent<CircleCollider2D> ().enabled = false;
			b.GetComponent<CircleCollider2D> ().enabled = false;
			TimeToEnter = true;
			onon=true;
			//HelpButton.OnHelp = false;
		}
		if (transform.position.y >= 0 && TimeToEnter==true) {
			if(movespeed<0)
				movespeed=0.1f;
			else if(movespeed>transform.position.y){
				transform.position= new Vector2(0,-0.37f);
				movespeed=0;
			}
			else if(transform.position.y>=2.91f){
				movespeed+=Time.deltaTime;
			}
			else{
				movespeed-=Time.deltaTime;
			}
			gameObject.transform.Translate(0,-1*movespeed,0);
		}
		else if (transform.position.y <=0&&TimeToEnter==true) {
			TimeToEnter=false;
			myMoney.text = Load.TotalMoney.ToString();
		}
		else if (TimeToLeave==true) {
			if(transform.position.y<-8f){
				TimeToLeave=false;
				gameObject.transform.position = new Vector2 (0,10);
				BuyButton.onBuy = false;
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
			
			gameObject.transform.Translate(0,-1*movespeed,0);
			Debug.Log("eee");
		}
	}
	void OnMouseDown(){
		if(transform.position.y<=0&&!TimeToLeave==true)
			myMoney.text = "";
			TimeToLeave = true;
	}
}
