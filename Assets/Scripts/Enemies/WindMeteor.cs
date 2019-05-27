using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMeteor : MonoBehaviour {

	public GameObject windMeteorExplosion;
	public float meteorSpeed;
	
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
        if (col.gameObject.tag.Equals("Player"))
        {
			Destroy(this.gameObject);
			GameObject windBlow = Instantiate(windMeteorExplosion) as GameObject;
            windBlow.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject.FindGameObjectWithTag("Shake").GetComponent<CinemachineCameraShake>().ShakeTheCamera(true);
			Destroy(windBlow, 2);
        } 

		if (col.gameObject.tag.Equals("Ground"))
        {
			Destroy(this.gameObject);
			GameObject windBlow = Instantiate(windMeteorExplosion) as GameObject;
            windBlow.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			Destroy(windBlow, 2);
        } 

		if (col.gameObject.tag.Equals("Wall"))
        {
			Destroy(this.gameObject);
			GameObject windBlow = Instantiate(windMeteorExplosion) as GameObject;
            windBlow.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			Destroy(windBlow, 2);
        } 
		if(col.gameObject.tag.Equals("DeathZone")){
			Destroy(this.gameObject);
		}
    }
}
