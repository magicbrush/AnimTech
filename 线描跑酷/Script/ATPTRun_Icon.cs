using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPTRun_Icon : MonoBehaviour {

	public Transform _Src;
	public bool _bPos = true, _bScl = false, _bRot = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_bPos) {
			transform.localPosition = _Src.localPosition;
		}
		if(_bScl){
			Vector3 lscl = _Src.localScale;
			lscl.z = 1.0f;
			transform.localScale = lscl;
		}
		if (_bRot) {
			transform.localRotation = _Src.localRotation;
		}
	}
}
