using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AT_RandTorque : MonoBehaviour {

	public KeyCode _Key= KeyCode.S;
	public float _TorqueMultiplier;


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
