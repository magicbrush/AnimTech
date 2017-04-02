using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATScaleByAnimCurve : MonoBehaviour {

	public AnimationCurve _ScaleCurve;
	private float _StartTime = 0.0f;
	private bool _Scaling = false;
	public float _Mulitplier = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!_Scaling)
			return;
		
		float T = Time.realtimeSinceStartup - _StartTime;

		float s = _Mulitplier * _ScaleCurve.Evaluate (T);
		transform.localScale = new Vector3 (s, s, 1.0f);
	}

	public void BeginScaling()
	{
		_Scaling = true;
		_StartTime = Time.realtimeSinceStartup;
	}
}
