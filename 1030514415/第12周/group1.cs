using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class group1 : MonoBehaviour {

	public float _Multiplier = 1.0f;
	public float _MaxForce = 1.0f;
	public float _MaxSpd = 1.0f;
	public float _MultipRand = 1.0f;
	public Vector3 aPos = new Vector3(0.0f,1.0f,0.0f);

	void Start ()
	{
		_Multiplier += Random.Range (-_MultipRand, _MultipRand);
	}

	void Update ()  //朝中心游走
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		if (rb == null) {
			return;
		}

		Vector3 intendVel =  aPos - transform.position;
		intendVel.Normalize ();
		intendVel *= _MaxSpd;

		Vector3 vel = rb.velocity;
		Vector3 force = intendVel - vel;
		if (force.magnitude > _MaxForce) {
			force = force.normalized * _MaxForce;
		}
		force *= _Multiplier;
		rb.AddForce (force);
	}

	void OnTriggerStay2D(Collider2D another)  //彼此分开
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		Vector2 vel = rb.velocity;

		Vector2 separationVel = 
			transform.position - another.transform.position;
		separationVel = 
			separationVel.normalized* _MaxSpd;

		Vector2 force = separationVel - vel;
		if (force.magnitude > _MaxForce) {
			force = force.normalized * _MaxForce;
		}
		force *= _Multiplier;
		rb.AddForce (force);
	}
}


