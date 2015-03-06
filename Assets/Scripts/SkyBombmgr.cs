using UnityEngine;
using System.Collections;

public class SkyBombmgr : MonoBehaviour {
	private float cost;
	// Use this for initialization
	public bool isChecked;
	public float originX,originY;
	public float x,y;
	public SkyBomb bombPrefab;
	public SkyBomb bomb;
	
	public bool keyChecked;
	void Start () {
		cost = 15f;
		isChecked = false;
		originX = transform.position.x;
		originY = transform.position.y;
		keyChecked = false;
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
		
		if (Input.GetMouseButtonUp(0) && y > -3&&isChecked) { // Chcek if the skill should be casted! 
			
			if(mpbar.curmp>=cost){
				bomb =(SkyBomb) Instantiate(bombPrefab,new Vector3(x+3,y+3,0),Quaternion.identity);
				bomb.setDes(x,y);
				mpbar.curmp-=cost;
			}
			
			x = originX;
			y = originY;
			transform.position = new Vector3 (x, y, 0);
			
		}
		else if (Input.GetMouseButtonUp(0) && y <= -3&&isChecked) { // Chcek if the skill should be casted! 
			x = originX;
			y = originY;
			transform.position = new Vector3 (x, y, 0);
			
		}
		if (Input.GetKeyDown(KeyCode.Q)) {
			if (PauseControl.play == false) {
				return;
			}
			keyChecked = true;	
		}
		if (Input.GetKeyUp (KeyCode.Q)) {
			if(y>-3){
				if(mpbar.curmp>=cost){
					bomb =(SkyBomb) Instantiate(bombPrefab,new Vector3(x+3,y+3,0),Quaternion.identity);
					bomb.setDes(x,y);
					mpbar.curmp-=cost;
				}
			}
			x = originX;
			y = originY;
			transform.position = new Vector3 (x, y, 0);
			keyChecked = false;
		}
		if (keyChecked) {
			if (PauseControl.play == false) {
				return;
			}
			
			float ratio,temp;
			ratio = (Screen.height / 10.2f);
			temp = (Screen.width - 5 * ratio )/2;
			x = (Input.mousePosition.x / ratio)-2.8f;
			y =( Input.mousePosition.y / ratio)-5.2f;
			transform.position = new Vector3 (x,y,0);
		}
		
		
	}
	
	void OnMouseDown(){
		if (PauseControl.play == false) {
			return;
		}
		
		isChecked = true;	
	}
	void OnMouseDrag(){
		if (PauseControl.play == false) {
			return;
		}
		
		float ratio,temp;
		ratio = (Screen.height / 10.2f);
		temp = (Screen.width - 5 * ratio )/2;
		Debug.Log (temp);
		x = (Input.mousePosition.x / ratio)-2.8f;
		y =( Input.mousePosition.y / ratio)-5.2f;
		transform.position = new Vector3 (x,y,0);
	}
	
	void OnMouseUp(){
	}
	
	
	
}
