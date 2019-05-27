using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorInstantiator : MonoBehaviour {

public GameObject inimigoPrefab;
    float tempo;
    public float instanceTime;
    float x;
    float y;
    float z;

	// Use this for initialization
	void Start () {
        tempo = Time.time;	
        z = transform.position.z;
        x = transform.position.x;
        y = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - tempo > instanceTime)
        {
            GameObject go = Instantiate(inimigoPrefab) as GameObject;
            go.transform.position = new Vector3(x, y, z);
            go.transform.rotation = this.gameObject.transform.rotation;
            tempo = Time.time;
        }
	}
}