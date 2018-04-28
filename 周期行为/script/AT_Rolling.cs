using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_Rolling : MonoBehaviour {
	public float _AngleDegSpd = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float angle = 
			_AngleDegSpd * Time.realtimeSinceStartup;
		Quaternion rot =
			Quaternion.AngleAxis (angle, Vector3.forward);
		transform.localRotation = rot;
	}
}
