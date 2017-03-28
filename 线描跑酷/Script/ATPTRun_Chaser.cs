using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPTRun_Chaser : MonoBehaviour {
	public ATPT_BrushSprite _TgtBrSprite;
	public bool _bChasing = false;
	public float _Speed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		if (_bChasing && _TgtBrSprite != null) {
			Vector3 Shift = 
				_TgtBrSprite.transform.position - transform.position;
			Vector3 TgtVel = Shift.normalized;
			Vector3 Vel = rb.velocity;

			Vector3 Force = _Speed * (TgtVel - Vel);

			rb.AddForce (Force);
		} else {
			rb.velocity *= 0.95f;
		}


	}

	public void TurnOnChasing()
	{
		_bChasing = true;
	}

	public void TurnOffChasing()
	{
		_bChasing = false;
	}

	public void OnTriggerStay2D(Collider2D other)
	{
		ATPT_BrushSprite brs = other.GetComponent<ATPT_BrushSprite> ();
		if (brs != null) {
			brs.Die ();
		}
	}
}
