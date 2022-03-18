using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rezultats : MonoBehaviour {
	public float Timer = 0.0f;
	public Objekti objektuSkripts;
	public int minutes;
	public int seconds ;
	public int milliseconds;
	private bool speleIet = false;

	void Start(){
		speleIet = true;
	}
		
	// Update is called once per frame
	void Update () {
		if (speleIet == true) {
			Timer += Time.deltaTime;
			minutes = Mathf.FloorToInt (Timer / 60F);
			seconds = Mathf.FloorToInt (Timer % 60F);
			milliseconds = Mathf.FloorToInt ((Timer * 100F) % 100F);
		} 
		if (objektuSkripts.skaits == 11) {
			speleIet = false;
			objektuSkripts.laikaRaditajs.GetComponent<Text> ().text = "Laiks: "+ minutes.ToString ("00") + ":" + seconds.ToString ("00") + ":" + milliseconds.ToString ("00");
			if (Timer <= 60.0f) {
				objektuSkripts.Zvaigzne3.SetActive (true);
			} else if (Timer <= 120.0f) {
				objektuSkripts.Zvaigzne2.SetActive (true);
			} else if (Timer >= 120.0f){
				objektuSkripts.Zvaigzne1.SetActive (true);
			}
		}
	}


}
