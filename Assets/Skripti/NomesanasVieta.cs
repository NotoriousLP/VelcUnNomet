﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NomesanasVieta : MonoBehaviour, IDropHandler {
	//Uzglabās velkamā objekta un nomešanas lauka z rotāciju,
	// kā arī rotācijas un izmēru pieļaujamo starpību
	private float vietasZrot, velkObjZrot, rotacijasStarpiba;
	private Vector2 vietasIzm, velkObjIzm;
	private float xIzmeruStarp, yIzmeruStarp;
	//Norāde uz objekti skriptu
	public Objekti objektuSkripts;

	//Nostrādas, ja objektu cenšas nomest uz jebkuras nomešanas vietas
	public void OnDrop(PointerEventData notikums){
		//Pārbauda vai tika vilkts un atlaists vispār kāds objekts
		if (notikums.pointerDrag != null) {
			//Ja nomešanas vietas tags sakrīt ar vilktā objekta tagu
			if (notikums.pointerDrag.tag.Equals (tag)) {
				//Iegūst objekta rotāciju grādos
				vietasZrot = notikums.pointerDrag.GetComponent<RectTransform> ().eulerAngles.z;
				velkObjZrot = GetComponent<RectTransform> ().eulerAngles.z;
				//Aprēķina abu objektu z rotācijas starpību
				rotacijasStarpiba = Mathf.Abs (vietasZrot - velkObjZrot);
				//Līdzīgi kā ar Z rotāciju, jāpiefiksē objektu izmēri pa x un y asīm, kā arī starpība
				vietasIzm = notikums.pointerDrag.GetComponent<RectTransform> ().localScale;
				velkObjIzm = GetComponent<RectTransform> ().localScale;
				xIzmeruStarp = Mathf.Abs (vietasIzm.x - velkObjIzm.x);
				yIzmeruStarp = Mathf.Abs (vietasIzm.y - velkObjIzm.y);


				//Pārbauda vai objektu rotācijas un izmēru starpība ir pieļaujamās robežās
				if ((rotacijasStarpiba <= 6 || (rotacijasStarpiba >= 354 && rotacijasStarpiba <= 360))
				    && (xIzmeruStarp <= 0.1 && yIzmeruStarp <= 0.1)) {
					objektuSkripts.vaiIstajaVieta = true;
					//Noliktais objekts smuki iecentrējas nomešanas laukā
					notikums.pointerDrag.GetComponent<RectTransform> ().anchoredPosition = 
										GetComponent<RectTransform> ().anchoredPosition;
					//Rotācijai
					notikums.pointerDrag.GetComponent<RectTransform> ().localRotation = 
										GetComponent<RectTransform> ().localRotation;
					//Izmēram
					notikums.pointerDrag.GetComponent<RectTransform> ().localScale = 
						GetComponent<RectTransform> ().localScale;
					//Pārbauda taga un atskaņo atbilstošo skaņas efektu
					switch (notikums.pointerDrag.tag) {
					case "Atikrumi": 
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [1]);
						objektuSkripts.skaits++; //pieskaita
						break;
					case "AtraPalidziba": 
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [2]);
						objektuSkripts.skaits++; //pieskaita
						break;
					case "Skola": 
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [3]);
						objektuSkripts.skaits++; //pieskaita
						break;
						//Pievienoti vēl 8 objekti/mašīnas
					case"Eskavators":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [9]);
						objektuSkripts.skaits++; //pieskaita
						break;
					case"e46":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [4]);
						objektuSkripts.skaits++; //pieskaita
						break;
					case"b2":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [5]);
						objektuSkripts.skaits++; //pieskaita
						break;
					case"Policija":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [6]);
						objektuSkripts.skaits++; //pieskaita
						break;
					case"Traktors1":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [7]);
						objektuSkripts.skaits++; //pieskaita
						break;
					case"Traktors5":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [8]);
						objektuSkripts.skaits++; //pieskaita
						break;
					case"Uguns":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [10]);
						objektuSkripts.skaits++; //pieskaita
						break;
					case"CementaMasina":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [11]);
						objektuSkripts.skaits++; //pieskaita
						break;
					default:
						Debug.Log ("Nedefinēts tags!");
						break;
					}

				}
				//Ja objekts nomests nepareizajā laukā
			} else {
				objektuSkripts.vaiIstajaVieta = false;
				objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [0]);

				//Objektu aizmet uz sākotnējo pozīciju
				switch (notikums.pointerDrag.tag) {
				case "Atikrumi": 
					objektuSkripts.atkritumaMasina.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.atkrKoord;
					break;
				case "AtraPalidziba": 
					objektuSkripts.atraPalidziba.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.atroKoord;
					break;
				case "Skola": 
					objektuSkripts.autobuss.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.bussKoord;
					break;
					//Pievienoti vēl 8 objekti/mašīnas
				case"Eskavators":
					objektuSkripts.eskavators.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.eskaKoord;
					break;
				case"e46":
					objektuSkripts.e46.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.e46Koord;
					break;
				case"b2":
					objektuSkripts.b2.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.b2Koord;
					break;
				case"Policija":
					objektuSkripts.policija.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.policijaKoord;
					break;
				case"Traktors1":
					objektuSkripts.traktors1.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.trakt1Koord;
					break;
				case"Traktors5":
					objektuSkripts.traktors5.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.trakt5Koord;
					break;
				case"Uguns":
					objektuSkripts.ugunsDzesejs.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.ugunsKoord;
					break;
				case"CementaMasina":
					objektuSkripts.cementaMasina.GetComponent<RectTransform> ().localPosition 
					= objektuSkripts.cementKoord;
					break;
				default:
					Debug.Log ("Nedefinēts tags!");
					break;
				}
			}
		}
		//Pārbaudis ja skaititajs ir 11 tad izmetīs panelis, ka tu esi visu izdarījis
		if (objektuSkripts.skaits == 11) {
			objektuSkripts.rezultatuTabula.SetActive (true);
			objektuSkripts.teksts.SetActive (true);
			objektuSkripts.atkartotSpeli.SetActive (true);
			objektuSkripts.atgrieztiesGalvena.SetActive (true);
		}
	}

}

