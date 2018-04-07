using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AT_Absorbit))]
[RequireComponent(typeof(Rigidbody2D))]
public class AT_MassOnAbsorbitAmt : MonoBehaviour {

	public float _MassMultiplier = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		AT_Absorbit absorbit = GetComponent<AT_Absorbit> ();
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();

		rb.mass = _MassMultiplier * absorbit.GetC ();
	}
}
