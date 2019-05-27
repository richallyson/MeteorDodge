using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour {

	GameMaster gameMaster;

	void Start(){
		gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
	}

	// Use this for initialization
	public void ReturnToMenu () {
		SceneManager.LoadScene("MainMenu");
	}

	public void RestartFase(){
		SceneManager.LoadScene(gameMaster.levelName);
	}
}
