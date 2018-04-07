using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_ScaleOnAbsorbitAmt : MonoBehaviour {
	public AT_Absorbit _absorbit;
	public float _Pow = 0.5f;
	public float _Multiplier = 1.0f;
	
	// Update is called once per frame
	void Update () {
		float amt = _absorbit.GetC ();
		float density = _absorbit.GetRho ();
		float scl = _Multiplier * amt / Mathf.Pow( density, _Pow);
		Vector3 Scl = (Vector3)(scl * Vector2.one);
		transform.localScale = Scl;
	}
}
