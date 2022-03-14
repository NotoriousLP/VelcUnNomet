using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Importē, lai varētu ielādēt ainas
using UnityEngine.SceneManagement;


public class IzvelesSkripts : MonoBehaviour {

	public void uzSpeli(){
		//Iejies galvenajā ainā
		SceneManager.LoadScene ("Pilseta", LoadSceneMode.Single);
	}

	public void beigtSpeli(){
		//Izies ārā no spēles
		Application.Quit ();
	}
}
