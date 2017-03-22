using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT周期振动12 : MonoBehaviour {

	public float _XAmplitude,_XFreq, _XPhase;
	public float _YAmplitude,_YFreq, _YPhase;

	public float _SAmplitude,_SFreq, _SPhase;
	public float _SBase = 0.5f;
	public float _SAmplitude2,_SFreq2, _SPhase2;


	public float _RotSpd = 1.0f;

	public float _BAmplitude,_BFreq, _BPhase;
	public float _BBase = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float T = Time.realtimeSinceStartup;
		OscillateLocalPosition (T);
		OscillateScale (T);
		OscillateOrientation ();

		OscillateBrightness (T);


	}

	void OscillateOrientation ()
	{
		Vector3 RotAng = new Vector3 (
			0, 0, _RotSpd* Time.deltaTime);
		transform.Rotate (RotAng);
	}

	void OscillateLocalPosition (float T)
	{
		float x, y;
		x = _XAmplitude * Mathf.Sin (_XFreq * T + _XPhase);
		y = _YAmplitude * Mathf.Sin (_YFreq * T + _YPhase);
		transform.localPosition = new Vector3 (x, y, 0);
	}

	void OscillateScale (float T)
	{
		float S1 = _SBase + 
			_SAmplitude * Mathf.Sin (
				_SFreq * T + _SPhase);
		float S2 = _SAmplitude2 * Mathf.Sin (
			_SFreq2 * T + _SPhase2);
		float S = S1 + S2;
		transform.localScale = new Vector3 (S, S, 1.0f);
	}

	void OscillateBrightness (float T)
	{
		float B = _BBase + 
			_BAmplitude * Mathf.Sin (
				_BFreq * T + _BPhase);
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		Color cr = sr.color;
		float Hue, Sat, Val;
		Color.RGBToHSV (cr, out Hue, out Sat, out Val);
		Color cr2 = Color.HSVToRGB (Hue, Sat, B);
		sr.color = cr2;
	}
}
