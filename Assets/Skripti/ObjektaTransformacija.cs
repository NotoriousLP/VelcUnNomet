using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektaTransformacija : MonoBehaviour {
	public Objekti objektuSkripts;


	// Update is called once per frame
	void Update () {
		//Ja ir vilkts kāds objekts, tad to varēs koriģēt
		if (objektuSkripts.pedejaisVilktais != null) {
			//Nospiežot Z taustiņu rote pretēji pulksteņradītāja virzienam
			if(Input.GetKey(KeyCode.Z)){
				objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().Rotate (0, 0, Time.deltaTime * 16);
			}
			//Nospiežot X taustiņu rote pulksteņradītāja virzienam
			if (Input.GetKey (KeyCode.X)) {
				objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().Rotate (0, 0, Time.deltaTime * -16);
			}

			if(Input.GetKey(KeyCode.UpArrow)){
				if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().localScale.y<= 0.8f) {
					objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().localScale 
					= new Vector2 (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().localScale.x,
					objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().localScale.y + 0.001f);
				}
			}

			if (Input.GetKey (KeyCode.DownArrow)) {
				if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().localScale.y >= 0.3f) {
					objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().localScale 
				= new Vector2 (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().localScale.x,
						objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().localScale.y - 0.001f);
				}
			}


			if(Input.GetKey(KeyCode.RightArrow)){
					if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().localScale.y <= 0.8f) {
						objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().localScale 
					= new Vector2 (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().localScale.x + 0.001f,
							objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().localScale.y);
					}
			}
			if(Input.GetKey(KeyCode.LeftArrow)){
					if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().localScale.y >= 0.3f) {
						objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().localScale 
						= new Vector2 (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().localScale.x - 0.001f,
							objektuSkripts.pedejaisVilktais.GetComponent<RectTransform> ().localScale.y);
					}
				}
		}

	}
}



