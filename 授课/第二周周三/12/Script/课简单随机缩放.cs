using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 课简单随机缩放 : MonoBehaviour {

	public float _速率 = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float X方向尺度变化 = 
			 Random.Range (-0.01f, 0.01f);
		float Y方向尺度变化 = 
			Random.Range (-0.01f, 0.01f);

		transform.localScale +=
			new Vector3 (
				X方向尺度变化,
				Y方向尺度变化,
				0) * _速率;
		
	}
}
