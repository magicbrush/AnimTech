using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT力的实验 : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		Rigidbody rb = GetComponent<Rigidbody> ();

		Vector3 Force = Random.insideUnitSphere;

		rb.AddForce (Force);

	}


}
