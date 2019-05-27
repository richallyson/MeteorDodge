using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaseSelect : MonoBehaviour {

	GameMaster gameMaster;

	public void Start(){
		gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
	}

	public void Back(){
		SceneManager.LoadScene("MainMenu");
	}

	public void Fase1(){
		if(gameMaster.levelPass == 0){
			SceneManager.LoadScene("Fase1");
		}
	}

	public void Fase2(){
		if(gameMaster.levelPass == 1){
			SceneManager.LoadScene("Fase2");
		}
	}

	public void Fase3(){
		if(gameMaster.levelPass == 2){
			SceneManager.LoadScene("Fase3");
		}
	}

	public void Fase4(){
		if(gameMaster.levelPass >= 3){
			SceneManager.LoadScene("Fase4");
		}
	}
}
