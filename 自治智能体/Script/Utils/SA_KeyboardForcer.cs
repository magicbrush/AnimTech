using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmartAgent
{
	public class SA_KeyboardForcer : MonoBehaviour {

		public KeyCode _Up,_Down,_Right,_Left;
		public float _ForcePower = 1.0f;
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			Vector2 force = Vector2.zero;
			if (Input.GetKey (_Up)) {
				force += Vector2.up;
			}
			if (Input.GetKey (_Down)) {
				force += Vector2.down;
			}
			if(Input.GetKey(_Right))
			{
				force += Vector2.right;
			}
			if (Input.GetKey (_Left)) {
				force += Vector2.left;
			}

			if (force.magnitude > 0.0f) {
				force = force.normalized * _ForcePower;
				Rigidbody2D rb = GetComponent<Rigidbody2D> ();
				rb.AddForce (force);
			}

		}
	}
}
