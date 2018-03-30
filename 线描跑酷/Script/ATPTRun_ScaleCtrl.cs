using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPTRun_ScaleCtrl : MonoBehaviour {

	public ATTraceRunner _Runner;
	public float _MinScale = 0.01f,_MaxScale = 0.03f;
	public float _NormScale = 0.02f;
	public float _Acc = 1.0f;
	public KeyCode _Upkey = KeyCode.Q,_DownKey=KeyCode.E;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float dt = Time.deltaTime;
		float tgtScl = _NormScale;

		if (Input.GetKey (_Upkey)) {
			tgtScl = _MaxScale;
		}
		else if (Input.GetKey (_DownKey)) {
			tgtScl = _MinScale;
		}

		float scl = transform.localScale.x;

		float scl2 = Mathf.Lerp (scl, tgtScl, dt * _Acc);

		transform.localScale = scl2 * Vector3.one;
		
	}
}
