using UnityEngine;
using System.Collections;

public class Tomb : MonoBehaviour {
	public int number;
	public float lr;
	public float endX;
	public float ratioY;
	public float speed;
	public Sprite[] sprites;


	void Start () {
		transform.position = new Vector3 (0,5f,0);


	}
	public void setNumber(){
		number = Random.Range (0, 3);
		ratioY = calY (endX);
		lr = Random.Range (-1f, 1f);
		if (lr <= 0)
			endX *= -1; 

		//Sprite sprite = textures[Array.IndexOf(names, "textureName")];
		if (lr <= 0) {
			switch (number) {
			case 0:
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("MuBei_0");
				break;
			case 1:
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("MuBei_2");
				break;
			case 2:
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("MuBei_4");
				break;
			case 3:
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("MuBei_6");
				break;
				
			}
		} 
		else {
			switch (number) {
			case 0:
				gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("MuBei_1");
				break;
			case 1:
				gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("MuBei_3");
				break;
			case 2:
				gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("MuBei_5");
				break;
			case 3:
				gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("MuBei_7");
				break;
				
			}
		}
	}
	public void setSpeed(float f){
		speed = f;
	}
	void FixedUpdate(){

		if (PauseControl.play == false) {
			return;
		}

		float temp = -(transform.position.y - 5) / 10;
		transform.Translate (new Vector3 (endX/9.0f*speed*(temp+1),-speed*(temp+1), 0)*Time.deltaTime);
		
		transform.localScale = new Vector3(temp,temp,temp);
		if (transform.position.y < -8)
			Destroy (gameObject);
	}
	public void setendX(float end){
		endX = end;
	}

	float calY(float x){
		float temp;
		temp = 885 / endX;
		return temp;
	}
}
