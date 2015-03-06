using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Num0 : MonoBehaviour {
	
	public int num0;
	public RectTransform num0rect;
	public int total;
	public Image mi;
	public Num1 num1;
	// Use this for initialization
	public static int getScore;
	void Start () {
		getScore = 0;
		num0 = 0;
		total = 0;
		num0rect = gameObject.GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (PauseControl.play == false) {
			return;
		}

		if (getScore>0) {
			total = total+1;
			getScore-=1;
			num0= (num0+1);
			if(num0>=10){
				Num1.getScore10 +=1;
			}
			num0=num0%10;
			
			
			if(num0==0){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("zero");
			}
			else if(num0==1){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("one");
			}
			else if(num0==2){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("two");
			}
			else if(num0==3){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("three");
			}
			else if(num0==4){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("four");
			}
			else if(num0==5){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("five");
			}
			else if(num0==6){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("six");
			}
			else if(num0==7){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("seven");
			}
			else if(num0==8){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("eight");
			}
			else if(num0==9){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("nine");
			}
			
		}
		if (total == 10) {
			Movebyscore (1);
			num1.Movebyscore(1);
		}
		else if (total == 100) {
			Movebyscore (2);
			num1.Movebyscore(2);
		}
	}
	void Movebyscore(int s){
		if (s == 1) {
			num0rect.anchoredPosition = new Vector2 (159f, 627f);
		} 
		else if (s == 2) {
			num0rect.anchoredPosition = new Vector2 (322f,627f);
		}
		else{
			num0rect.anchoredPosition = new Vector2(0,627f);
		}
	}
}
