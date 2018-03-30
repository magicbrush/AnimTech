using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class TrailColorOnColorModel : MonoBehaviour {
	public ColorModel _colorModel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Color cr = _colorModel.GetDispColor ();
		TrailRenderer tr = GetComponent<TrailRenderer> ();
		tr.startColor = cr;
		Color cr2 = cr;
		cr2.a = 0.0f;
		tr.endColor = cr2;
	}
}
