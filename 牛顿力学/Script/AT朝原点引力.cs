using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT朝原点引力 : MonoBehaviour {

	public float _强度 = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		if (rb == null) {
			return;
		}

		Vector3 LocalPos = transform.localPosition;
		Vector3 Force = -LocalPos.normalized * _强度 * 0.01f;

		rb.AddForce (Force);
		
	}
}
