using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMeteorVertical : MonoBehaviour {

	public GameObject fireMeteorExplosion;
	public float meteorSpeed;
	public GameObject meteorExplosion;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * meteorSpeed);
		Destroy(this.gameObject, 5);
	}

	
	public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
			Destroy(this.gameObject);
			GameObject explosion = Instantiate(fireMeteorExplosion) as GameObject;
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			GameObject exploded = Instantiate(meteorExplosion) as GameObject;
			exploded.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			Destroy(explosion, 2);
			Destroy(exploded, 2);
        } 

		if (col.gameObject.tag.Equals("Ground"))
        {
			GameObject.FindGameObjectWithTag("Shake").GetComponent<CinemachineCameraShake>().ShakeTheCamera(true);
			Destroy(this.gameObject);
			GameObject explosion = Instantiate(fireMeteorExplosion) as GameObject;
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			GameObject exploded = Instantiate(meteorExplosion) as GameObject;
			exploded.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			Destroy(explosion, 2);
			Destroy(exploded, 2);
        } 

		if (col.gameObject.tag.Equals("Wall"))
        {
			GameObject.FindGameObjectWithTag("Shake").GetComponent<CinemachineCameraShake>().ShakeTheCamera(true);
			Destroy(this.gameObject);
			GameObject explosion = Instantiate(fireMeteorExplosion) as GameObject;
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			GameObject exploded = Instantiate(meteorExplosion) as GameObject;
			exploded.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			Destroy(explosion, 2);
			Destroy(exploded, 2);
        }
		if(col.gameObject.tag.Equals("DeathZone")){
			Destroy(this.gameObject);
		}
    }
}
