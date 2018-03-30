using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPTRun_Speed : MonoBehaviour {

	public ATTraceRunner _TR;
	public float _MinSpd = 0.1f,_MaxSpd = 1.0f;
	public float _Power = 1.0f,_Brake = 3.0f;
	public KeyCode _Key = KeyCode.Space;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float spd = _TR.GetSpeed (); 
		float tgtSpd = _MinSpd;
		float acc = _Brake;
		if (Input.GetKey (_Key)) {
			tgtSpd = _MaxSpd;
			acc = _Power;
		} 
		spd = Mathf.Lerp (spd, tgtSpd, Mathf.Clamp01 (acc * Time.deltaTime));
		_TR.SetSpeed (spd);
	}
}
