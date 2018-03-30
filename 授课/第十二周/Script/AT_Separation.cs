using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_Separation : MonoBehaviour {
	public float _MaxSpd = 1.0f;
	public float _MaxForce = 1.0f;
	public float _Multiplier = 1.0f;
	public float _MultipRand = 1.0f;

	// Use this for initialization
	void Start () {
		_Multiplier += Random.Range (-_MultipRand, _MultipRand);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D another)
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
