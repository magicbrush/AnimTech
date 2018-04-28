using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_YSinT : MonoBehaviour {

	public float _Amplitude = 1.0f;
	public float _Frequence = 1.0f;
	public float _Phase = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float T = Time.realtimeSinceStartup;

		float Y = _Amplitude * Mathf.Sin (_Frequence * T + _Phase);

		Vector3 locPosNow = 
			transform.localPosition;
		locPosNow.y = Y;
		transform.localPosition = locPosNow;
	}
}
