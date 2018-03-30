using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmartAgent
{
	//[RequireComponent(typeof(Collider2D))]
	public class SA_Align : SmartAgentBase {

		public string _TargetTag;
		private HashSet<Rigidbody2D> _Neighbors = new HashSet<Rigidbody2D>();

		// Use this for initialization
		void Start () {
			
		}

		public override Vector2 EstimateOptimalVel()
		{
			/*
			Rigidbody2D rb = GetComponent<Rigidbody2D> ();
			Vector2 vel = rb.velocity;
			if (vel.magnitude > _MaxSpd) {
				vel = vel.normalized * _MaxSpd;
			}*/
			Vector2 vel = Vector2.zero;
			return vel;
		}

		void OnTriggerStay2D(Collider2D other)
		{
			Debug.Log ("other:" + other.name);
			/*
			Rigidbody2D rb = other.GetComponent<Rigidbody2D> ();
			if (rb != null && rb.tag == _TargetTag ) {
				_Neighbors.Add (rb);
			}*/
		}

	}
}
