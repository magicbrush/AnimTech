using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmartAgent
{
	public class SA_Neighbors : MonoBehaviour {

		public HashSet<Rigidbody2D> _Neighbors = 
			new HashSet<Rigidbody2D>();

		void Update()
		{
			_Neighbors.Clear ();
		}

		void OnTriggerStay2D(Collider2D other)
		{
			Debug.Log ("Other:" + other);
			Rigidbody2D rb = other.attachedRigidbody;
			_Neighbors.Add (rb);
		}
	}
}
