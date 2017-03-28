using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPTRun_CameraCtrl : MonoBehaviour {

	public Camera _Cam;
	private Vector3 _OriginPos;
	public float _MinSize=0.2f,_NormalSize = 0.8f;
	public float _LerpSpd = 1.0f;
	private bool _bFollowing = false;

	// Use this for initialization
	void Start () {
		_OriginPos = _Cam.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;

		float tgtSize = _NormalSize;
		Vector3 tgtPos = _OriginPos;
		if (_bFollowing) {
			tgtSize = _MinSize;
			tgtPos = transform.position;
			tgtPos.z = _OriginPos.z;
		} 

		float size = _Cam.orthographicSize;
		Vector3 pos = _Cam.transform.position;
		size = Mathf.Lerp (
			size, tgtSize, Mathf.Clamp01(dt * _LerpSpd));
		pos = Vector3.Lerp (
			pos, tgtPos, Mathf.Clamp01( dt * _LerpSpd));

		_Cam.orthographicSize = size;
		_Cam.transform.position = pos;
		
	}

	public void TurnOnFollowing()
	{
		_bFollowing = true;
	}
	public void TurnOffFollowing()
	{
		_bFollowing = false;
	}
}
