using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKeyFrameDemo3 : MonoBehaviour {

	public AnimationCurve _HueOnScale;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float scl = transform.localScale.x;
		float Hue = _HueOnScale.Evaluate (scl);

		Color cr = Color.HSVToRGB (Hue, 1.0f, 1.0f);

		SpriteRenderer spr = GetComponent<SpriteRenderer> ();
		spr.color = cr;

		
	}
}
