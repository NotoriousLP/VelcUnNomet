using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jāimporte, lai lietotu visus I interfeisus
using UnityEngine.EventSystems;

public class DragDropSkripts : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {
	//Velkamajam objektam piestiprinātā kompoente
	private CanvasGroup kanvasGrupa;
	//Priekš pārvietojamā objekta atrašās vietas uzglabāšanās
	private RectTransform velkObjRectTransf;
	//Norāde uz objektu skriptu
	public Objekti objektuSkripts;

	// Use this for initialization
	void Start () {
		//Piekļūst objekta piestiprinātajai CanvasGroup komponentei
		kanvasGrupa = GetComponent<CanvasGroup>();
		// Piekļūst objekta RectTransform komponentei
		velkObjRectTransf = GetComponent<RectTransform>();
	}
	
	public void OnPointerDown(PointerEventData notikums){
		Debug.Log ("Kreisais klikškis uz objekta!");
	}

	public void OnBeginDrag(PointerEventData notikums){
		Debug.Log ("Uzsākta objekta vilkšana!");
		//Velkot objektu, tas paliek caurspīdīgs
		kanvasGrupa.alpha = 0.6F;
		//Lai objektu velkot iet cauri raycast stari
		kanvasGrupa.blocksRaycasts = false;
		objektuSkripts.pedejaisVilktais = null;
	}

	public void OnDrag(PointerEventData notikums){
		//Maina objekta x,y koordinātas
		velkObjRectTransf.anchoredPosition += notikums.delta / objektuSkripts.kanva.scaleFactor;	
	}

	public void OnEndDrag(PointerEventData notikums){
		Debug.Log ("Objekta vilkšana pārtraukta!");
		kanvasGrupa.alpha = 1.0F;
		objektuSkripts.pedejaisVilktais = notikums.pointerDrag;
		//Ja objekts nebija nolikts īstajā vietā
		if (objektuSkripts.vaiIstajaVieta == false) {
			// Tad to atkal var vilkt
			kanvasGrupa.blocksRaycasts = true;

			// ja nolikts īstajā vietā
		} else {
			// Aizmirst pēdejo objektu, kas vilkts 
			objektuSkripts.pedejaisVilktais = null;
		}
			//Ja viens objekts nolikts īstajā vietā, tad lai varētu turpināt vilkt pārejos
			//iestata uz false
			objektuSkripts.vaiIstajaVieta = false;
	}
}
