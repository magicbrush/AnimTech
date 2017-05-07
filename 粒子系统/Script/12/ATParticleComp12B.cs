using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ATParticleComp12B : MonoBehaviour {
	
	public float _TorqueMultiplier = 1.0f;
	public KeyCode _Key = KeyCode.A;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (_Key)) {
			Rigidbody2D rb = GetComponent<Rigidbody2D> ();
			rb.AddTorque (
				_TorqueMultiplier * (Random.value-0.5f));
		}
	}
}
