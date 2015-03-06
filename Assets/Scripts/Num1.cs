using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Num1 : MonoBehaviour {
	
	private int num1;
	public RectTransform num1rect;
	public Num0 num0;
	
	public Num2 num2;
	// Use this for initialization
	public static int getScore10;
	
	void Start () {
		getScore10 = 0;
		num1rect = gameObject.GetComponent<RectTransform> ();
		num1 = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (PauseControl.play == false) {
			return;
		}



		if (getScore10>0) {
			
			getScore10 -=1;
			
			num1= (num1+1);
			if(num1>=10){
				Num2.getScore100 +=1;
			}
			num1=num1%10;
			
			if(num1==0){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("zero");
			}
			else if(num1==1){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("one");
			}
			else if(num1==2){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("two");
			}
			else if(num1==3){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("three");
			}
			else if(num1==4){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("four");
			}
			else if(num1==5){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("five");
			}
			else if(num1==6){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("six");
			}
			else if(num1==7){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("seven");
			}
			else if(num1==8){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("eight");
			}
			else if(num1==9){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("nine");
			}
			
		}
		
	}
	public void Movebyscore(int s){
		if (s == 1) {
			num1rect.anchoredPosition = new Vector2 (-159f, 627f);
		} 
		else if (s == 2) {
			
			num2.Movebyscore(2);
			num1rect.anchoredPosition = new Vector2 (0,627f);
		}
	}
}
