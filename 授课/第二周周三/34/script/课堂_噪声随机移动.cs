using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 课堂_噪声随机移动 : MonoBehaviour {

	public float _速率 = 1.0f;
	public float _跨度 = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float X = 
			Mathf.PerlinNoise (
				_速率*Time.realtimeSinceStartup,
				0);
		float Y = 
			Mathf.PerlinNoise (
				_速率*Time.realtimeSinceStartup,
				10000.0f);

		transform.localPosition = 
			new Vector3 (X, Y, 0) * _跨度;
		
	}
}
