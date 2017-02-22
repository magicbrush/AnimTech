using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 课噪声变色 : MonoBehaviour {

	private float[] _偏移量 = 
		new float[4]{0,0,0,0};

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 4; i++) {
			_偏移量 [i] = 
				Random.Range (-100.0f, 100.0f);
		}

	}
	
	// Update is called once per frame
	void Update () {
		SpriteRenderer sr = 
			GetComponent<SpriteRenderer> ();

		float 时刻 = Time.realtimeSinceStartup;
		Color 当前颜色 = sr.color;
		当前颜色.r = Mathf.PerlinNoise (
			时刻, _偏移量[0]);
		当前颜色.g = Mathf.PerlinNoise(
			时刻, _偏移量[1]);
		当前颜色.b = Mathf.PerlinNoise(
			时刻, _偏移量[2]);
		当前颜色.a = Mathf.PerlinNoise(
			时刻, _偏移量[3]);
		sr.color = 当前颜色;

		
	}
}
