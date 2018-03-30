using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEffectorOnColor : MonoBehaviour {
	public ColorModel _colorModel;

	public PointEffector2D _effector;

	public float _RadiusOnAmountSqrt = 1.0f;
	public float _ForceMagOnAmount = -1.0f;
	
	// Update is called once per frame
	void Update () {
		float colorAmt = _colorModel.GetColorAmount ();
		float radius = Mathf.Sqrt(colorAmt) * _RadiusOnAmountSqrt;

		CircleCollider2D cld = GetComponent<CircleCollider2D> ();
		cld.radius = radius;

		_effector.forceMagnitude = colorAmt * _ForceMagOnAmount;
	}



}
