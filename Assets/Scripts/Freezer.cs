using System.Collections;
using UnityEngine;

public class Freezer : MonoBehaviour {

	[Range(0f, 8f)]
	public float duration = 1f;

	bool _isFronzen = false;
	float _pendingFreezeDuration = 0f;
	private static Freezer _instance;


	// Update is called once per frame
	void Awake () {

		if(!_instance){
			_instance = this ;
		}else{
			Destroy(this.gameObject) ;
		}
		
		DontDestroyOnLoad(this.gameObject);		
	}
	
	void Update () {
		if(_pendingFreezeDuration > 0 && !_isFronzen){
			StartCoroutine(DoFreeze());
		}
	}

	public void Freeze(){
		_pendingFreezeDuration = duration;
	}

	IEnumerator DoFreeze(){
		_isFronzen = true;
		var original = Time.timeScale;
		Time.timeScale = 0f;

		yield return new WaitForSecondsRealtime(duration);

		Time.timeScale = original;
		_pendingFreezeDuration = 0f;
		_isFronzen = false;
	}
}
