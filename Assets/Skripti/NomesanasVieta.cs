using System.Collections;
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
						break;
					case "AtraPalidziba": 
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [2]);
						break;
					case "Skola": 
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [3]);
						break;
					case"CementaMasina":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanaKoAtskanot [3]);
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
		
	}

}

