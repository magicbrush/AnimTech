using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVelocity : MonoBehaviour {
	// RandomVector3

	public AT_MovingInDir _movingInDir;

	public float _MinSpd = 0.5f,_MaxSpd = 2.0f;

	// Use this for initialization
	void Start () {
		float spd = Random.Range (_MinSpd, _MaxSpd);
		Vector3 vel = Random.insideUnitCircle * spd;
		_movingInDir.SetVelocity (vel);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
