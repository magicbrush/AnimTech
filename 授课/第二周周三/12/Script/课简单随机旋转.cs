using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 课简单随机旋转 : MonoBehaviour {

	public float _速率 = 10.0f;
	
	// Update is called once per frame
	void Update () {
		float 旋转角度 = Random.Range (
			-_速率, _速率);
		transform.Rotate (
			Vector3.forward, 旋转角度);
		

	}
}
