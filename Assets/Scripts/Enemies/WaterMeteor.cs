using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMeteor : MonoBehaviour {
	public float meteorSpeed;
	public GameObject waterSplash;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * meteorSpeed);
		Destroy(this.gameObject, 5);
	}

	
	public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {	
			waterSplash.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			GameObject splash = Instantiate(waterSplash) as GameObject;
			Destroy(this.gameObject);
			Destroy(splash, 2);
			
        }

		if(col.gameObject.tag.Equals("Player")){
			waterSplash.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			GameObject splash = Instantiate(waterSplash) as GameObject;
			Destroy(this.gameObject);
			Destroy(splash, 2);
		} 
		if(col.gameObject.tag.Equals("DeathZone")){
			Destroy(this.gameObject);
		}
    }
	
}
