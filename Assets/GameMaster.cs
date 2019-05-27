using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	public string levelName;
	public int levelPass = 0;
	private static GameMaster _instance;

	// Use this for initialization
	void Awake () {
		if(!_instance){
			_instance = this ;
		}else{
			Destroy(this.gameObject) ;
		}


		DontDestroyOnLoad(this.gameObject);		
	}

	public void setScene(string scene){
		this.levelName = scene;
	}

	public void addPass(){
		if(levelPass > 3){
			levelPass = 3;
		}else{
			levelPass++;
		}
	}

}
