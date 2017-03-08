using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT振子原型 : MonoBehaviour {

	private LineRenderer _LR;
	public float _ZDepth = 5.0f;

	// Use this for initialization
	void Start () {
		_LR = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 LPos = transform.localPosition;
		Vector3 LPos2 = LPos;
		LPos2.z = _ZDepth;
		_LR.SetPosition (1, -LPos2);
	}
}
