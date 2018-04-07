using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class ATColorForceTrailDisp : MonoBehaviour {

	public AT_ColorForce _colorForce;

	// Update is called once per frame
	void Update () {
		TrailRenderer tr = GetComponent<TrailRenderer> ();
		tr.startColor = _colorForce._Color;
		tr.endColor = _colorForce._Color;
	}
}
