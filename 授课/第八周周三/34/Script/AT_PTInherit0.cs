using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_PTInherit0 : AT_PTBase {

	public float _TorqueMultiplier = 1.0f;
	
	public override void MyAction()
	{
		base.MyAction ();

		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.AddTorque (_TorqueMultiplier * (Random.value-0.5f));
	}


}
