using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BuyScriptInShop : MonoBehaviour {
	public Animator ani;
	public int cost;
	public int what; // 1 =cloth
	public int which;
	public Text changeMoney;

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
		if(Load.TotalMoney >=cost){
			
			Load.TotalMoney -= cost;
			PlayerPrefs.SetInt ("equalSkin",which);
			changeMoney.text = Load.TotalMoney.ToString();
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
