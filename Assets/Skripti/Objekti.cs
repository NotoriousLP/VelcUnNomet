using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objekti : MonoBehaviour {
	//Uzglabā ainā esošo kanvu
	public Canvas kanva;
	//GameObject, kas uzglabā velkamos objektus
	public GameObject atkritumaMasina;
	public GameObject atraPalidziba;
	public GameObject autobuss;
	public GameObject cementaMasina;
	public GameObject eskavators;
	public GameObject e46;
	public GameObject b2;
	public GameObject policija;
	public GameObject traktors1;
	public GameObject traktors5;
	public GameObject ugunsDzesejs;


	//Uzglabā velkamo objektu sākotnējās atrašanās vietas koordinātas
	[HideInInspector]
	public Vector2 atkrKoord;
	[HideInInspector]
	public Vector2 atroKoord;
	[HideInInspector]
	public Vector2 bussKoord;
	[HideInInspector]
	public Vector2 cementKoord;
	[HideInInspector]
	public Vector2 eskaKoord;
	[HideInInspector]
	public Vector2 e46Koord;
	[HideInInspector]
	public Vector2 policijaKoord;
	[HideInInspector]
	public Vector2 trakt1Koord;
	[HideInInspector]
	public Vector2 trakt5Koord;
	[HideInInspector]
	public Vector2 ugunsKoord;
	[HideInInspector]
	public Vector2 b2Koord;


	//Uzglabās audio avotu, kurā atskaņot attēlu skaņas efektus
	public AudioSource skanasAvots;
	//Masīvs, kas uzglabā visas iespējamās skaņas
	public AudioClip[] skanaKoAtskanot;
	//Mainīgais piefiksē vai objekts nolikts īstajāvietā (true/false)
	[HideInInspector]
	public bool vaiIstajaVieta = false;
	//Uzglabās pēdejo objektu, kurš pakustināts
	public GameObject pedejaisVilktais = null;

	void Start() {
		atkrKoord = atkritumaMasina.GetComponent<RectTransform> ().localPosition;
		atroKoord = atraPalidziba.GetComponent<RectTransform> ().localPosition;
		bussKoord = autobuss.GetComponent<RectTransform> ().localPosition;
		cementKoord = cementaMasina.GetComponent<RectTransform> ().localPosition;
		eskaKoord = eskavators.GetComponent<RectTransform> ().localPosition;
		e46Koord = e46.GetComponent<RectTransform> ().localPosition;
		policijaKoord = policija.GetComponent<RectTransform> ().localPosition;
		trakt1Koord = traktors1.GetComponent<RectTransform> ().localPosition;
		trakt5Koord = traktors5.GetComponent<RectTransform> ().localPosition;
		ugunsKoord = ugunsDzesejs.GetComponent<RectTransform> ().localPosition;
		b2Koord = b2.GetComponent<RectTransform> ().localPosition;
	}




}
