using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    int possoPular;
    public int speed;
    public int jumpForce;
    Rigidbody rb;
    Freezer _freezer;
    GameMaster gameMaster;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        gameMaster.setScene(SceneManager.GetActiveScene().name);

        GameObject mgr = GameObject.FindWithTag("Manager");

        if(mgr){
            _freezer = mgr.GetComponent<Freezer>();
        }
    }

    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            rb.velocity = new Vector3(speed * Input.GetAxis("Horizontal"), rb.velocity.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && possoPular > 0)
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Force);
        }        
    }

    public void Death() {
       if (true){
            StartCoroutine(DeathDelayer());      
        }
    }
    
    public IEnumerator DeathDelayer(){
        var original = Time.timeScale;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1.0f);
        Time.timeScale = original; 
        Destroy(this.gameObject);
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    public void IncreaseFriction(Collision col){
        if(col.gameObject.tag.Equals("Water Meteor")){
            StartCoroutine(Slippery());
        }
    }

    public IEnumerator Slippery(){
        if(this.speed == 12){
            this.speed += 18;
        }
        yield return new WaitForSecondsRealtime(5.0f);
        if(this.speed == 30){
            this.speed -= 18;
        }
    }

    public void JumpGravity(){
        if(true){
            StartCoroutine(JumpDownForce());
        }
    }

    public IEnumerator JumpDownForce(){
        yield return new WaitForSecondsRealtime(0.3f);
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * 800);
    }
  
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            possoPular++;
        }

        if (col.gameObject.tag.Equals("EarthMeteor")){
            Death();
        } 

        if (col.gameObject.tag.Equals("FireMeteor")){
            Death();
        } 

        if(col.gameObject.tag.Equals("Water Meteor")){
            IncreaseFriction(col);  
            Debug.Log(speed);  
        }
        
        if(col.gameObject.tag.Equals("WindMeteor")){
            GameObject.FindGameObjectWithTag("WindBlow").GetComponent<WindExplosion>().FixedUpdate();
        }
    }

    void OnParticleCollision(GameObject other){
         if(other.gameObject.tag.Equals("FireExplosion")){
            Debug.Log("Hit!");
            Death();
        }
    }

    public void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            possoPular--;
            JumpGravity();
        }
    }

    public void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag.Equals("bola")){
            _freezer.Freeze();
            Destroy(col.gameObject);
        }
    }

    
}

