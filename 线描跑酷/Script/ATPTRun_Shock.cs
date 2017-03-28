using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPTRun_Shock : MonoBehaviour {

	public float _Duration = 0.8f;
	public float _Power = 1.0f;
	private float _Left = 0.0f;

	public KeyCode _Key = KeyCode.LeftShift;
	public AnimationCurve _DecayCurve;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_Left > 0.0f) {
			float dt = Time.deltaTime;
			float leftNorm = _Left / _Power;
			float k = _DecayCurve.Evaluate (1.0f - leftNorm);
			transform.localPosition += 0.01f * _Power * k *
				(Vector3)Random.insideUnitCircle;
			_Left -= dt;
		}

		if(Input.GetKey(_Key))
		{
			Exert ();
		}
		
	}

	public void Exert()
	{
		_Left = _Duration;
	}
}
