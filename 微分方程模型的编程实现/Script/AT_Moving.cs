using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_Moving : MonoBehaviour {

	public Vector3 _Velocity = Vector3.right;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition += _Velocity * Time.deltaTime;
	}
}
