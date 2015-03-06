using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class PauseScript : MonoBehaviour {

	// Use this for initialization
	public RectTransform rect;
	public Dictionary<GameObject, float> speeds = new Dictionary<GameObject, float>(); 
	public TextScript t;
	public GameObject resume;
	public Text human;  
	public GameObject restart;
	public GameObject bgm;
	public AudioClip failM;
	void Start () {
		rect = gameObject.GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Exit(){
		foreach (Item item in GameObject.FindObjectsOfType(typeof(Item)) ){
			item.destroyCheck();
		}
		
		Load.TotalMoney += ShowMoney.coinNum;
		PlayerPrefs.SetInt ("TotalMoney", Load.TotalMoney);
		PlayerPrefs.SetInt ("MPPotion",Load.MPPotion);
		PlayerPrefs.SetInt ("MPHealer", Load.MPHealer);
		PlayerPrefs.SetInt ("Star", Load.Star);


		Application.LoadLevel ("menu");
	}

	public void GoToScreen(){

		restart.SetActive (false);
		t.DetermineText (true);
		rect.anchoredPosition =new Vector2 (0, 0);
		PauseControl.play = false;
		int i;

		object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
		foreach (object o in obj)
		{
			GameObject g = (GameObject) o;
			
			Animator a ;
			if(g.GetComponent<Animator>()!=null){
				a = g.GetComponent<Animator>();
				speeds.Add(g,a.speed);
				a.speed = 0; 
				
				
			}
			
		}


	}



	public void Restart(){

		foreach (Item item in GameObject.FindObjectsOfType(typeof(Item)) ){
			item.destroyCheck();
		}

		Load.TotalMoney += ShowMoney.coinNum;
		PlayerPrefs.SetInt ("TotalMoney", Load.TotalMoney);
		PlayerPrefs.SetInt ("MPPotion",Load.MPPotion);
		PlayerPrefs.SetInt ("MPHealer", Load.MPHealer);
		PlayerPrefs.SetInt ("Star", Load.Star);

		Application.LoadLevel ("scene");

	}


	public void GameOver(){



		audio.PlayOneShot (failM);
		bgm.SetActive (false);

		resume.SetActive (false);
		restart.SetActive (true);
		t.DetermineText (false);
		string s = ManManager.humanAlreadyKilled.ToString () + " Huamns Eaten!";
		Debug.Log (s);
		human.GetComponent<Text>().text = s;
		rect.anchoredPosition =new Vector2 (0, 0);
		PauseControl.play = false;
		int i;



		object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
		foreach (object o in obj)
		{
			GameObject g = (GameObject) o;
			
			Animator a ;
			if(g.GetComponent<Animator>()!=null){
				a = g.GetComponent<Animator>();
				speeds.Add(g,a.speed);
				a.speed = 0; 
				
				
			}
			
		}





	}



	public void MoveOut(){
		rect.anchoredPosition =new Vector2 (1098, 0);
		object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
		foreach (object o in obj)
		{
			GameObject g = (GameObject) o;
			
			Animator a ;
			float temp;
			if(g.GetComponent<Animator>()!=null){

				a = g.GetComponent<Animator>();
				speeds.TryGetValue(g,out temp);
				a.speed = temp;
				
				
			}
			
		}

		speeds.Clear ();


		PauseControl.play = true;
		t.DetermineText (false);
	}
}
