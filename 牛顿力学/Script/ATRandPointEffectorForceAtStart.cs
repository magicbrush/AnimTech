using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PointEffector2D))]
public class ATRandPointEffectorForceAtStart : MonoBehaviour {

	public float ForceMin = -20.0f, ForceMax = 20.0f;
	// Use this for initialization
	void Start () {
		PointEffector2D effector = GetComponent<PointEffector2D> ();
		float f = Random.Range (ForceMin, ForceMax);
		effector.forceMagnitude = f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
