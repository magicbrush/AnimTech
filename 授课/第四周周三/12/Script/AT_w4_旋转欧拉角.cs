using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_w4_旋转欧拉角 : MonoBehaviour {

	public Vector3 _旋转速度;
	public float _旋转速率 = 1.0f;

	// Use this for initialization
	void Start () {
		_旋转速度 = Random.insideUnitSphere;
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;

		transform.Rotate (_旋转速度 * _旋转速率);

		
	}
}
