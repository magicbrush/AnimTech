using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_MovingInDir : MonoBehaviour {
	public Vector3 _Velocity= Vector3.right;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = _Velocity * Time.deltaTime;
		Vector3 localPosition = transform.localPosition;
		localPosition += movement;
		transform.localPosition = localPosition;
		
	}
}
