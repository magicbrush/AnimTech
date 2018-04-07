using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ATColorForceColorDisp : MonoBehaviour {
	public AT_ColorForce _colorForce;
	
	// Update is called once per frame
	void Update () {
		SpriteRenderer spr = GetComponent<SpriteRenderer> ();
		spr.color = _colorForce._Color;
	}
}
