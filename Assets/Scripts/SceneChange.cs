using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

    public Object scene;
    GameMaster gameMaster;

	// Use this for initialization
	void Start () {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag.Equals("Player")){
            gameMaster.addPass();
            SceneManager.LoadScene(scene.name);
        }
    }
}
