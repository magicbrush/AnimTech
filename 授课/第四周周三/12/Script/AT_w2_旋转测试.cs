using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_w2_旋转测试 : MonoBehaviour {

	public float _旋转速度 = 50.0f;
	public Vector3 _RotationAxis = Vector3.forward;

	// Use this for initialization
	void Start () {
		_RotationAxis = Random.insideUnitSphere;
	}
	
	// Update is called once per frame
	void Update () {

		float dt = Time.deltaTime;

		transform.Rotate (_RotationAxis, _旋转速度 * dt);
		
	}
}
