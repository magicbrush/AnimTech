using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATkeyFrameDemo2 : MonoBehaviour {
	public AnimationCurve _ScaleONXPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float scl = _ScaleONXPos.Evaluate (
			transform.localPosition.x);
		Vector3 LocScale = scl * Vector3.one;

		transform.localScale = LocScale;
	}
}
