using UnityEngine;
using System.Collections;

public class Dizzy : MonoBehaviour {
	public human h;
	public float timeout;
	void Start () {
		timeout = 0f;
	}

	void Update () {

		if (PauseControl.play == false) {
			return;
		}

		timeout += Time.deltaTime;
		if (timeout > 3f || h.dieflag == true || (h.transform.position.x * h.transform.position.x + h.transform.position.y * h.transform.position.y) > 6.25) {
			h.haveDizzy = false;
			Destroy (gameObject);
		}gameObject.transform.position = new Vector2 (h.transform.position.x, h.transform.position.y + 2f*h.scaleIndex);
	}
	public void geth(human hh){
		h = hh;
	}
}
