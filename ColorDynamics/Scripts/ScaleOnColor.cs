using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnColor : MonoBehaviour {
	public ColorModel _colorModel;

	public float _ScaleFactor = 1.0f;
	public float _Power = 2.0f;
	
	// Update is called once per frame
	[ContextMenu("Update")]
	void Update () {
		float scale = GetScale ();
		Vector3 localScale = scale * Vector3.one;
		transform.localScale = localScale;
	}

	public float GetScale()
	{
		float colorAmt = 
			_colorModel.GetColorAmount ();
		float density = _colorModel.GetDensity ();
		float scale = Mathf.Pow(colorAmt,1.0f/_Power) * _ScaleFactor/density;
		return scale;
	}
}
