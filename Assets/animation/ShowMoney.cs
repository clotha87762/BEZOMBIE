using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowMoney : MonoBehaviour {
	Text txt;
	public static int coinNum;
	public AudioClip moneyM;
	void Start () {
		txt = gameObject.GetComponent<Text>(); 
		coinNum = 0;
		txt.text=""+coinNum;
	}
	
	void Update () {
		txt.text=""+coinNum;
	}
	public void getCoin(){
		GetComponent<AudioSource>().PlayOneShot (moneyM);
		coinNum += 1;
	}
}
