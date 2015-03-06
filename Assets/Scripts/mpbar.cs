using UnityEngine;
using System.Collections;
//0,-6
public class mpbar : MonoBehaviour {
	public float maxmp;
	public static float curmp;
	public float maxmplocation;
	public float minmplocation;
	public float mplocation;
	public SpriteRenderer mpcolor;
	public float addingMana;
	public float autoHealCount;
	public static bool autoHeal;
	// Use this for initialization
	void Start () {
		autoHeal = false;
		autoHealCount = 150;
		addingMana = 0;
		maxmp = 100;
		curmp =50;
		maxmplocation = 0f;
		minmplocation = gameObject.transform.position.x;
		mplocation = minmplocation;
	}
	// Update is called once per frame
	void Update () {
		
		if (PauseControl.play == false) {
			return;
		}

		if (autoHeal) {
			autoHealCount-=0.2f;
			curmp += 0.2f;
			if (curmp >= maxmp)
				curmp = maxmp;
			if(autoHealCount<=0){
				autoHeal=false;
				autoHealCount=130;
			}

		}
		
		mplocation = ((curmp / maxmp) * (maxmplocation - minmplocation) + minmplocation);
		gameObject.transform.position = new Vector2 (mplocation, gameObject.transform.position.y);
		
		if (addingMana > 0) {
			curmp += 1;
			addingMana -=1;
			if (curmp >= maxmp)
				curmp = maxmp;
		}
		/*else if (addingMana < 0) {
			curmp -= 1;
			addingMana += 1;
			if (curmp <=0)
				curmp = 0;
		}*/
		
		mpcolor = GetComponent<SpriteRenderer>();
		mpcolor.color = new Color32((byte)((curmp / maxmp) * 155+100f), 0, (byte)((curmp / maxmp) * 155+100f), 255);
		
	}
	public void AdjMana(float f){
		
		addingMana += f;
		
	}


	
}
