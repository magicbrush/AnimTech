using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changer_Rolling : Changer {
	public float _RotSpd = 360.0f;

	public override void Change ()
	{
		float TNow = Time.realtimeSinceStartup;
		Quaternion rot = Quaternion.AngleAxis (
			TNow * _RotSpd, Vector3.forward);
		transform.localRotation = rot;
	}

}
