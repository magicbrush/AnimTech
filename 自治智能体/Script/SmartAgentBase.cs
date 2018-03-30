using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmartAgent
{
	public class SmartAgentBase : MonoBehaviour {

		public float _MaxSpd = 10.0f;
		public float _MaxForce = 10.0f;

		// Update is called once per frame
		void Update () {
			Vector2 opVel = EstimateOptimalVel ();

			Rigidbody2D rb = GetComponent<Rigidbody2D> ();
			Vector2 curVel = rb.velocity;
			Vector2 turnDirForce = opVel - curVel;
			if (turnDirForce.magnitude > _MaxForce) {
				turnDirForce = turnDirForce.normalized * _MaxForce;
			}
			rb.AddForce (turnDirForce);
		}

		public virtual Vector2 EstimateOptimalVel()
		{
			Rigidbody2D rb = GetComponent<Rigidbody2D> ();
			Vector2 vel = rb.velocity;
			if (vel.magnitude > _MaxSpd) {
				vel = vel.normalized * _MaxSpd;
			}
			return vel;
		}
	}
}
