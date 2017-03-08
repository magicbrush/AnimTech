using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_不断旋转 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;

		transform.Rotate (Vector3.forward, 10.0f*dt);

		
	}
}
