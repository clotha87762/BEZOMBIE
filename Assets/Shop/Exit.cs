using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Exit : MonoBehaviour {

	public Animator ani;
	public ShopScript ss;
	public GameObject shopitem1,shopitem2;
	public Text warning ;
	void Start () {
		
		ani =GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnMouseOver(){
		
		ani.SetBool ("isOver", true);
	}
	
	void OnMouseExit(){
		
		ani.SetBool ("isOver", false);
	}
	
	void OnMouseDown(){
		
		ani.SetBool ("isDown", true);
	}
	
	void OnMouseUp(){
		
		ani.SetBool ("isDown", false);
		
	}
	void OnMouseUpAsButton(){
		ani.SetBool ("isDown", false);
		if (ss.transform.position.y <= 0 && !ss.TimeToLeave == true) {


			foreach (CheckItem item in GameObject.FindObjectsOfType(typeof(CheckItem)) ){
				item.destroyCheck();
			}



			ss.myMoney.text = "";
			ss.TimeToLeave = true;
			warning.text ="";
			if(shopitem2.activeSelf){
				shopitem2.SetActive(false);
				shopitem1.SetActive(true);

			}
		}
		
		
	}

}
