using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindExplosion : MonoBehaviour {
    public GameObject WindBomb;
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	public void FixedUpdate () {
        if (WindBomb == enabled){
            Invoke("Detonate", 0);
        }
	}

    void Detonate(){
        Vector3 explosionPosition = WindBomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach(Collider hit in colliders){
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null){
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
            }
        }
    }
}