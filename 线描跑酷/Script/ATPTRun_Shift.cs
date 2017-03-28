using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPTRun_Shift : MonoBehaviour {

	public KeyCode 
		_Up=KeyCode.W, 
		_Down=KeyCode.S, 
		_Right=KeyCode.D, 
		_Left=KeyCode.A;

	public float _MaxShift = 0.2f;
	public float _TgtSpd = 1.0f;
	public float _ShiftSpd = 1.0f;
	public float _RestoreSpd = 1.0f;
	private Vector2 _TgtPos=Vector2.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;

		Vector2 Vel = Vector2.zero;
		if (Input.GetKey (_Up)) {
			Vel.y += 1.0f;
		}
		if (Input.GetKey (_Down)) {
			Vel.y -= 1.0f;
		}
		if (Input.GetKey (_Left)) {
			Vel.x -= 1.0f;
		}
		if (Input.GetKey (_Right)) {
			Vel.x += 1.0f;
		}
		if (Vel.magnitude > 0.0f) {
			Vel.Normalize ();
			Vel *= _TgtSpd;
		}
		_TgtPos += Vel * Time.deltaTime;
		if (_TgtPos.magnitude > _MaxShift) {
			_TgtPos = _TgtPos.normalized * _MaxShift;
		}
		_TgtPos *= (1.0f - Mathf.Clamp01 (_RestoreSpd * dt));

		Vector3 pos = transform.localPosition;
		float z = pos.z;
		pos = Vector3.Lerp (pos, (Vector3)_TgtPos, Mathf.Clamp01(_ShiftSpd * dt));
		pos.z = z;
		transform.localPosition = pos;
	}
}
