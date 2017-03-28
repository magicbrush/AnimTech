using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPTRun_BrushTrailCtrl : MonoBehaviour {

	public float _BaseWidth = 0.01f;
	public ATPTRun_ScaleCtrl _Scaler;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TrailRenderer TR = GetComponent<TrailRenderer> ();

		float normScl = _Scaler._NormScale;
		float scl = _Scaler.transform.localScale.x;
		float wd = _BaseWidth * scl / normScl;

		TR.widthMultiplier = wd;
		
	}
}
