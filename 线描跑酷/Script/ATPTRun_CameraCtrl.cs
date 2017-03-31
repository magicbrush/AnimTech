using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPTRun_CameraCtrl : MonoBehaviour {

	public Camera _Cam;
	public Vector3 _OriginPos = new Vector3(0.0f,0.0f,-10.0f);
	public float _MinSize=0.2f,_NormalSize = 0.8f;
	public float _LerpSpd = 1.0f;
	private bool _bFollowing = false;

	// Use this for initialization
	void Start () {
		
	}

	[ContextMenu("TakeCamOriginPosition")]
	public void TakeCamOriginPosition()
	{
		_OriginPos = _Cam.transform.position;
		Debug.Log ("TakeOriginPos" + _OriginPos);
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;

		float tgtSize = _NormalSize;
		Vector3 tgtPos = _OriginPos;

		if (float.IsNegativeInfinity (tgtPos.x)) {
			//Debug.Log ("OtgtPos:" + tgtPos);
			//float m = 12341234.0f;
			_OriginPos = new Vector3 (0, 1, -16.0f);
		}
		if (_bFollowing) {
			tgtSize = _MinSize;
			tgtPos = transform.position;
			tgtPos.z = _OriginPos.z;
			//Debug.Log ("atgtPos:" + tgtPos);
		} 

		float size = _Cam.orthographicSize;
		Vector3 pos = _Cam.transform.position;
		size = Mathf.Lerp (
			size, tgtSize, Mathf.Clamp01(dt * _LerpSpd));
		pos = Vector3.Lerp (
			pos, tgtPos, Mathf.Clamp01( dt * _LerpSpd));
		//Debug.Log ("_Cam.transform.position:" + pos + " tgtPos:" + tgtPos);
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
