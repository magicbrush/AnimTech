using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AT振子原型 : MonoBehaviour {

	private LineRenderer _LR;
	public float _ZDepth = 5.0f;

	public float _LeftEnergy = 10.0f;
	public UnityEvent _EnergyExhausted;

	private Vector3 _PrevPos = Vector3.zero;

	public SpriteRenderer _SpriteRenderer;

	public bool _bExhausting = false;

	public GameObject _Brush;

	// Use this for initialization
	void Start () {
		_LR = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_LeftEnergy <= 0.0f) {
			return;
		}

		Vector3 LPos = transform.localPosition;
		Vector3 LPos2 = LPos;
		LPos2.z = _ZDepth;
		_LR.SetPosition (1, -LPos2);

		if (_bExhausting) {
			ExhaustEnergy ();
		}
	}

	void ExhaustEnergy ()
	{
		Vector3 LScl = transform.localScale;
		float Scl = LScl.x * LScl.y;
		float alpha = _SpriteRenderer.color.a;
		float Power = alpha * Scl;
		_LeftEnergy -= Power * Time.deltaTime;
		if (_LeftEnergy <= 0.0f) {
			_EnergyExhausted.Invoke ();
		}
	}
		

	public void TurnOnExausting()
	{
		_bExhausting = true;
	}

	public void TurnOffExausting()
	{
		_bExhausting = false;
	}

	public void AddEnergy(float Amt)
	{
		_LeftEnergy += Amt;
	}

	public void ActivateBrush()
	{
		_Brush.SetActive (true);
	}

	public void DeactivateBrush()
	{
		_Brush.SetActive (false);
	}



	/*
	void OnCollisionStay2D(Collision2D coll)
	{
		Debug.Log (gameObject.name + " OnCollisionStay2D");
	}

	void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log (gameObject.name + " OnTriggerStay2D");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log (gameObject.name + "OnTriggerEnter2D");
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log (gameObject.name + "OnCollisionEnter2D");
	}*/

}
