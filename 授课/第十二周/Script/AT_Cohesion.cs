using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_Cohesion : MonoBehaviour {

	public float _Multiplier = 1.0f;
	public float _MaxForce = 1.0f;
	public float _MaxSpd = 1.0f;
	public float _MultipRand = 1.0f;

	private List<Vector3> _Pos = new List<Vector3> ();

	// Use this for initialization
	void Start () {
		_Multiplier += Random.Range (-_MultipRand, _MultipRand);
	}
	
	// Update is called once per frame
	void Update () {

		if (_Pos.Count > 0) {
			Vector3 center = Vector3.zero;
			foreach (Vector3 v3 in _Pos) {
				center += v3;
			}
			center /= (float)_Pos.Count;

			Rigidbody2D rb = GetComponent<Rigidbody2D> ();
			Vector3 intendVel =  center - rb.transform.position;
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

		_Pos.Clear ();
	}

	void OnTriggerStay2D(Collider2D other)
	{
		Rigidbody2D rb2 = other.GetComponent<Rigidbody2D> ();
		if (rb2 == null) {
			return;
		}

		_Pos.Add (rb2.transform.position);
	}
}
