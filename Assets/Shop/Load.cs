using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {
	public static int TotalMoney;
	public static int equalSkin;
	public static int MPPotion;
	public static int MPHealer;
	public static int Star;
	// Use this for initialization
	void Start () {
		
		if (PlayerPrefs.HasKey ("TotalMoney")) {
			TotalMoney = PlayerPrefs.GetInt("TotalMoney");
		}
		else {
			PlayerPrefs.SetInt("TotalMoney",0);
		}
		if (PlayerPrefs.HasKey ("equalSkin")){ 
			equalSkin = PlayerPrefs.GetInt("equalSkin");
		}
		else {
			PlayerPrefs.SetInt("equalSkin",0);
		}

		if(PlayerPrefs.HasKey("MPPotion")){
			MPPotion = PlayerPrefs.GetInt("MPPotion");
		}
		else{
			PlayerPrefs.SetInt("MPPotion",0);
		}

		if(PlayerPrefs.HasKey("MPHealer")){
			MPHealer = PlayerPrefs.GetInt("MPHealer");
		}
		else{
			PlayerPrefs.SetInt("MPHealer",0);
		}

		if(PlayerPrefs.HasKey("Star")){
			Star = PlayerPrefs.GetInt("Star");
		}
		else{
			PlayerPrefs.SetInt("Star",0);
		}



	}

	static public void AdjustItem(string s,int x){

		if (s == "MPPotion") {
			MPPotion=x;
			PlayerPrefs.SetInt(s,x);
		} else if (s == "MPHealer") {
				MPHealer = x;
				PlayerPrefs.SetInt(s,x);
		} else if (s == "Star") {
				Star = x;
				PlayerPrefs.SetInt(s,x);
		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}