using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rezultats : MonoBehaviour {
	[HideInInspector]
	public float Timer = 0.0f;
	[HideInInspector]
	public Objekti objektuSkripts;
	[HideInInspector]
	public int minutes;
	[HideInInspector]
	public int seconds;
	[HideInInspector]
	public int milliseconds;

	private bool speleIet = false;

	//Ka startēsies spēle, tad automātiski spēleIet aizies uz true
	void Start(){
		speleIet = true;
	}
		

	void Update () {
		//Ja spēle vēl turpinās, tad skaitīs laiku līdz kamēr spēle beigsies
		if (speleIet == true) {
			//Pieskaita laiku
			Timer += Time.deltaTime;
			//Sadalīju laiku uz minūtēm,sekundēm un uz milisekundēm
			minutes = Mathf.FloorToInt (Timer / 60F);
			seconds = Mathf.FloorToInt (Timer % 60F);
			milliseconds = Mathf.FloorToInt ((Timer * 100F) % 100F);
		} 
		//Ja visas mašīnas ir noliktas vietā
		if (objektuSkripts.skaits == 11) {
			//Tad spēle beidzās
			speleIet = false;
			//Izmetīs laukā cik daudz laikā ir izdarīts
			objektuSkripts.laikaRaditajs.GetComponent<Text> ().text = "Laiks: "+ minutes.ToString ("00") + ":" + seconds.ToString ("00") + ":" + milliseconds.ToString ("00");
			//Ja laiks ir zemāk par 60 sekundēm, tad iedos tev 3 zvaigznes
			if (Timer <= 60.0f) {
				objektuSkripts.Zvaigzne3.SetActive (true);
				//Ja laiks ir zemāk par 120 sekundēm, tad iedos tev 2 zvaigznes
			} else if (Timer <= 120.0f) {
				objektuSkripts.Zvaigzne2.SetActive (true);
				//Ja laiks ir lielāks par 120 sekundēm, tad iedos tev 1 zvaigzni
			} else if (Timer > 120.0f){
				objektuSkripts.Zvaigzne1.SetActive (true);
			}
		}
	}


}
