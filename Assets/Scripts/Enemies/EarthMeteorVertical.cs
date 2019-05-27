using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMeteorVertical : MonoBehaviour {
	public float meteorSpeed;
	public float meteorRotateSpeed;
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
        if (col.gameObject.tag.Equals("Ground"))
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
