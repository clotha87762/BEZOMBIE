using UnityEngine;
using System.Collections;

public class Earthquake: MonoBehaviour {
	private float xm,ym,zm,dexm,deym,dezm;
	public int quaketime;
	public bool quakeflag;

	public AudioClip quakeMusic;
	// Use this for initialization
	void Start () {
		xm = 0;
		ym = 0; 
		zm = 0;
		quakeflag = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (PauseControl.play == false) {
			return;
		}


		if (Input.GetKey (KeyCode.K)){
			quake(5);
		}
		if (xm == 0 && ym == 0 && zm == 0 && quakeflag == true) {
			finishquake ();
		}
		else if(xm == 0 && ym == 0 && zm == 0 && quakeflag == false) {
			transform.position =new Vector3(0,0,-10);
			GetComponent<Camera>().orthographicSize = 5;
			if(quaketime!=0){
				quake (quaketime-1);
			}
			else GetComponent<AudioSource>().Stop ();
		}
		if (xm != 0) {
			float uxm = (xm>0)?Time.deltaTime*10:Time.deltaTime*10*-1f;
			if((xm>0&&uxm>xm)||(xm<0&&uxm<xm)){
				xm=0;
				uxm = 0;
			}
			else
				xm-=uxm;
			transform.Translate(uxm,0,0);

		}
		if (ym != 0) {
			float uym = (ym>0)?Time.deltaTime*10:Time.deltaTime*10*-1f;
			if((ym>0&&uym>ym)||(ym<0&&uym<ym)){
				ym=0;
				uym = 0;
			}
			else
				ym-=uym;
			transform.Translate(0,uym,0);

		}
		if (zm != 0) {
			float uzm = (zm>0)?Time.deltaTime*20:Time.deltaTime*20*-1f;
			if((zm>0&&uzm>zm)||(zm<0&&uzm<zm)){
				dezm-=zm;
				zm=0;
				uzm = 0;
			}
			else
				zm-=uzm;
			GetComponent<Camera>().orthographic = true;
			GetComponent<Camera>().orthographicSize -= uzm;
			if(GetComponent<Camera>().orthographicSize>5){
				zm=0;
				uzm = 0;
				GetComponent<Camera>().orthographicSize =5;
			}
		}
	}
	public void quake(int count){
		if (count == 5)
			GetComponent<AudioSource>().PlayOneShot (quakeMusic);
		quaketime = count;
		xm = Random.Range (0.2f, 0.3f);
		ym = Random.Range (0.4f, 0.5f);
		zm = Random.Range (0.5f,0.8f);
		float itemp = Random.Range(-1f, 1f);
		if (itemp >= 0)
			itemp = 1;
		else
			itemp = -1;
		xm *= itemp;

		itemp = Random.Range (-1f, 1f);
		if (itemp >= 0)
			itemp = 1;
		else
			itemp = -1;
		ym *= itemp;



		dexm = -xm;
		deym = -ym; 
		dezm = -zm;
		quakeflag = true;
	}
	public void finishquake(){
		xm = dexm;
		ym = deym; 
		zm = dezm;
		quakeflag = false;
	}
}
