using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IF_SetScaleCurve : MonoBehaviour {

	public AnimationCurve _Curve;
	public float _Mulitplier = 0.01f;
	public void SetScaleByAnimToParent()
	{
		ATScaleByAnimCurve sclByAnimCurve = 
			transform.parent.gameObject.AddComponent<ATScaleByAnimCurve> ();
		sclByAnimCurve.enabled = true;
		sclByAnimCurve._ScaleCurve = _Curve;
		sclByAnimCurve.BeginScaling ();
		sclByAnimCurve._Mulitplier = _Mulitplier;
	}
}
