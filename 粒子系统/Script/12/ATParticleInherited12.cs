using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATParticleInherited12 : ATParticleBase12 {

	public float _TorqueMultiplier = 1.0f;
	public override void RandomAction()
	{
		base.RandomAction ();

		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.AddTorque (
			_TorqueMultiplier * (Random.value-0.5f));
	}
}
