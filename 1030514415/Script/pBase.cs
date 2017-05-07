using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pBase : MonoBehaviour {

	public float  _ForcePower = 1.0f;
	public float _LifeSpan = 10.0f;

	void Start () {

	}

	public virtual void Update () {
		LifePassThenDie ();
		ApplyRandomForce ();
	}

	void LifePassThenDie ()
	{
		_LifeSpan -= Time.deltaTime;
		if (_LifeSpan < 0.0f) {
			Destroy (gameObject);
		}
	}

	void ApplyRandomForce ()
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (_ForcePower * Random.insideUnitCircle); //添加随机方向的力
	}
}
