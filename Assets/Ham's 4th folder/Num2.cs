using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Num2 : MonoBehaviour {
	
	private int num2;
	public RectTransform num2rect;
	public Num0 num0;
	// Use this for initialization
	public static int getScore100;
	
	void Start () {
		getScore100 = 0;
		num2rect = gameObject.GetComponent<RectTransform> ();
		num2 = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (getScore100>0) {

			getScore100 -=1;
			
			num2= (num2+1)%10;
			
			if(num2==0){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("zero");
			}
			else if(num2==1){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("one");
			}
			else if(num2==2){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("two");
			}
			else if(num2==3){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("three");
			}
			else if(num2==4){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("four");
			}
			else if(num2==5){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("five");
			}
			else if(num2==6){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("six");
			}
			else if(num2==7){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("seven");
			}
			else if(num2==8){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("eight");
			}
			else if(num2==9){
				gameObject.GetComponent<Image>().sprite= Resources.Load<Sprite>("nine");
			}
			
		}
		
	}
	public void Movebyscore(int s){
		if (s == 2) {
			num2rect.anchoredPosition = new Vector2 (-322,627f);
		}
	}
}
