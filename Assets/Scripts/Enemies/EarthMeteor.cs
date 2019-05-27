using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMeteor : MonoBehaviour {
	public float meteorSpeed;
	public GameObject meteorExplosion;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// transform.Rotate(Vector3.up, meteorRotationSpeed * Time.deltaTime);
		this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * meteorSpeed);
		Destroy(this.gameObject, 5);
	}

	
	public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
			GameObject.FindGameObjectWithTag("Shake").GetComponent<CinemachineCameraShake>().ShakeTheCamera(true);
			meteorExplosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			GameObject explosion = Instantiate(meteorExplosion) as GameObject;
			Destroy(this.gameObject);
			Destroy(explosion, 2);

        } 

		if (col.gameObject.tag.Equals("Player"))
        {
			GameObject.FindGameObjectWithTag("Shake").GetComponent<CinemachineCameraShake>().ShakeTheCamera(true);
			meteorExplosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			GameObject explosion = Instantiate(meteorExplosion) as GameObject;
			Destroy(this.gameObject);
			Destroy(explosion, 2);
        }

		if (col.gameObject.tag.Equals("Wall"))
        {
			GameObject.FindGameObjectWithTag("Shake").GetComponent<CinemachineCameraShake>().ShakeTheCamera(true);
			meteorExplosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			GameObject explosion = Instantiate(meteorExplosion) as GameObject;
			Destroy(this.gameObject);
			Destroy(explosion, 2);
        }

		if(col.gameObject.tag.Equals("DeathZone")){
			Destroy(this.gameObject);
		}
		
    }
}
