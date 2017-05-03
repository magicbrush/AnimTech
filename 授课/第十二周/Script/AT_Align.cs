using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_Align : MonoBehaviour {

	public float _MaxSpd = 1.0f;
	public float _MaxForce = 1.0f;
	public float _Multiplier = 1.0f;
	public float _RotAngle = 0.0f;

	public float _MultipRand = 1.0f;
	public float _RotRand = 180.0f;

	// Use this for initialization
	void Start () {
		_RotAngle += Random.Range (-_RotRand, _RotRand);
		_Multiplier += Random.Range (-_MultipRand, _MultipRand);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		Rigidbody2D rb2 = other.GetComponent<Rigidbody2D> ();
		if (rb2 == null) {
			return;
		}

		Vector3 vel2 = rb2.velocity;
		Vector3 intendVel =  _MaxSpd * vel2.normalized;
		intendVel = Quaternion.AngleAxis (_RotAngle, Vector3.forward) * intendVel;

		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		Vector3 vel = rb.velocity;

		Vector3 force = intendVel - vel;
		if (force.magnitude > _MaxForce) {
			force = force.normalized * _MaxForce;
		}

		force *= _Multiplier;
		rb.AddForce (force);
	}
}
