using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hpbar : MonoBehaviour {
	public RectTransform mptrans;
	public float maxmp;
	public float curmp;
	public float maxmplocation;
	public float minmplocation;
	public float mplocation;
	public Image mpcolor;
	public float addingMana;
	// Use this for initialization
	void Start () {
		mptrans = gameObject.GetComponent<RectTransform> ();
		addingMana = 0;
		maxmp = 100;
		curmp =0;
		float ratio = Screen.height / 350;
		maxmplocation = 13f*ratio;
		minmplocation = -56f * ratio;
		mplocation = minmplocation;
	}
	// Update is called once per frame
	void Update () {

		if (PauseControl.play == false) {
			return;
		}


		mplocation = ((curmp / maxmp) * (maxmplocation - minmplocation) + minmplocation);
		gameObject.transform.position = new Vector2 (mplocation, gameObject.transform.position.y);

		if (addingMana > 0) {
			curmp += 1;
			addingMana -= 1;
			if (curmp >= maxmp)
				curmp = maxmp;
		} 
		else if (addingMana < 0) {
			curmp -= 1;
			addingMana += 1;
			if (curmp <=0)
				curmp = 0;
		}

		mpcolor = GetComponent<Image>();
		mpcolor.color = new Color32((byte)((curmp / maxmp) * 255), 0, (byte)((curmp / maxmp) * 255), 255);



		//mp.color = new Color32((byte)((curmp / maxmp) * 255), 0, 0, 255);
		//gameObject.GetComponent(Image)
		/*if (Input.GetKey (KeyCode.Z)){
			curmp-=1;
		}
		if (Input.GetKey (KeyCode.X)){
			if(curmp+1>=maxmp)
				curmp=maxmp;
			else
				curmp+=1;
		}*/
	}
	public void AdjMana(float f){

		addingMana += f;

	}
}
