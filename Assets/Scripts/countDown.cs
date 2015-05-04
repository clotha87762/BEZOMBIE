using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class countDown: MonoBehaviour {
	public AudioClip count;
	public AudioClip start;
	public GameObject bgm;
	public GameObject coin;
	Text txt;
	float t=0.0f;
	int i=0;
	void Start(){	
		txt = gameObject.GetComponent<Text>();
	}
	void Update(){
		if (t >= 1.0f) {
			switch(i){
			case 0: {txt.text="three";GetComponent<AudioSource>().PlayOneShot(count);t=0.0f;i++;break;}
			case 1: {txt.text="two";GetComponent<AudioSource>().PlayOneShot(count);t=0.0f;i++;break;}
			case 2: {txt.text="one";GetComponent<AudioSource>().PlayOneShot(count);t=0.0f;i++;break;}
			case 3: {txt.text="start";GetComponent<AudioSource>().PlayOneShot(start);t=0.0f;i++;break;}
			case 4: {bgm.SetActive (true);PauseControl.play=true;coin.SetActive(true);Destroy (gameObject);break;}
			default: break;
			}
		} else t += Time.deltaTime;
	}
}
