using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT周期圆周 : MonoBehaviour {

	public float _AX=0.1f,_FX=5.0f,_PX=0.0f;
	public float _AY=0.1f,_FY=5.0f,_PY=Mathf.PI*0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.realtimeSinceStartup;

		float lx = _AX * Mathf.Sin (_FX * t + _PX);
		float ly = _AY * Mathf.Sin (_FY * t + _PY);

		Vector3 lpos = new Vector3 (lx, ly, 0.0f);
		transform.localPosition = lpos;
	}
}
