using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT振子原型 : MonoBehaviour {

	private LineRenderer _LR;
	public float _ZDepth = 5.0f;

	public float _LeftEnergy = 10.0f;

	private Vector3 _PrevPos = Vector3.zero;

	public SpriteRenderer _SpriteRenderer;

	public bool _bExausting = false;

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

		if (_bExausting) {
			ExaustEnergy ();
		}
	}

	void ExaustEnergy ()
	{
		Vector3 LScl = transform.localScale;
		float Scl = LScl.x * LScl.y;
		float alpha = _SpriteRenderer.color.a;
		float Power = alpha * Scl;
		_LeftEnergy -= Power * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{


	}

	public void TurnOnExausting()
	{
		_bExausting = true;
	}

	public void TurnOffExausting()
	{
		_bExausting = false;
	}

}
