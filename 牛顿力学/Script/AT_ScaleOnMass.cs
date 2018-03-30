using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AT_ScaleOnMass : MonoBehaviour {

	public float _SclMultiplier = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		float scl = _SclMultiplier*Mathf.Sqrt(rb.mass);
		Vector3 localScale = scl * Vector3.one;
		transform.localScale = localScale;
	}
}
