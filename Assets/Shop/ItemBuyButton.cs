using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ItemBuyButton : MonoBehaviour {

	public Animator ani;
	public int cost;
	public int what; // 1 =cloth
	public int which;
	public Text changeMoney;
	public Text warning;
	public string item;
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
		Debug.Log ((Load.MPHealer + Load.MPPotion + Load.Star).ToString());
		if(Load.TotalMoney >=cost){

			if(Load.MPHealer+Load.MPPotion+Load.Star<Item.limit){
			Load.TotalMoney -= cost;
			Load.AdjustItem(item,PlayerPrefs.GetInt(item)+1);
			
			changeMoney.text = Load.TotalMoney.ToString();
			}
			else{
				warning.text = "You Have Too Much Item!!";
			}
		}
	}


	void OnMouseUpAsButton(){
		/*ani.SetBool ("isDown", false);
		if(Load.TotalMoney >=cost){
		
			Load.TotalMoney -= cost;
			PlayerPrefs.SetInt ("equalSkin",which);
			changeMoney.text = Load.TotalMoney.ToString();
		}
		*/
		
	}
}
