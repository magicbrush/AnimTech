using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 课噪声旋转 : MonoBehaviour {

	public float _偏移量 = 0.0f;

	// Use this for initialization
	void Start () {
		_偏移量 = 
			Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {

		float 时刻 = Time.realtimeSinceStartup;
		float 旋转角度 = 
			Mathf.PerlinNoise (时刻, _偏移量);
		旋转角度 = 360.0f * 旋转角度 - 180.0f;
		Quaternion 方向 = Quaternion.AngleAxis 
			(旋转角度, Vector3.forward);
		transform.localRotation = 方向;
	}
}
