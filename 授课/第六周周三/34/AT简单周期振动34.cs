using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT简单周期振动34 : MonoBehaviour {

	public float XAmplitude, XFreq, XPhase;
	public float YAmplitude, YFreq, YPhase;
	public float SAmplitude, SFreq, SPhase;
	public float SBase;

	public float BAmplitude, BFreq, BPhase;
	public float BBase;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float T = Time.realtimeSinceStartup;
		OscillateTransform (T);
		OscillateSpriteRendererColor (T);
	}

	void OscillateTransform (float T)
	{
		OscillateLocalPosition (T);
		OscillateOrientation ();
		OscillateScaLE (T);
	}

	void OscillateScaLE (float T)
	{
		float S = SBase + SAmplitude * Mathf.Sin (SFreq * T + SPhase);
		transform.localScale = new Vector3 (S, S, 1.0f);
	}

	void OscillateLocalPosition (float T)
	{
		float X = XAmplitude * Mathf.Sin (XFreq * T + XPhase);
		float Y = YAmplitude * Mathf.Sin (YFreq * T + YPhase);
		transform.localPosition = new Vector3 (X, Y, 0.0f);
	}

	void OscillateOrientation ()
	{
		transform.Rotate (new Vector3 (0, 0, 1.0f));
	}

	void OscillateSpriteRendererColor (float T)
	{
		float B = BBase + BAmplitude * Mathf.Sin (BFreq * T + BPhase);
		SpriteRenderer SR = GetComponent<SpriteRenderer> ();
		float Hue, Sat, Val;
		Color.RGBToHSV (SR.color, out Hue, out Sat, out Val);
		Color cr2 = Color.HSVToRGB (Hue, Sat, B);
		SR.color = cr2;
	}
}
