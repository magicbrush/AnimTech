using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATkeyFrameDemo1 : MonoBehaviour {

	public AnimationCurve _HueCurve;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float TNow = Time.realtimeSinceStartup;
		float H = _HueCurve.Evaluate (TNow);

		Color crNow = Color.HSVToRGB (H, 1.0f, 1.0f);
		SpriteRenderer spr = GetComponent<SpriteRenderer> ();
		spr.color = crNow;
	}
}
