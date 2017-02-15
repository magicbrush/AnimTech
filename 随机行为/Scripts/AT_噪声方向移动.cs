using UnityEngine;
using System.Collections;

public class AT_噪声方向移动 : MonoBehaviour {

	public float _速率 = 0.01f;
	public float _随机变化速率 = 1.0f;

	private float _YStart;

	// Use this for initialization
	void Start () {
		_YStart = Random.value;
	}
	
	// Update is called once per frame
	void Update () {
		float 当前时刻_秒 = Time.realtimeSinceStartup;
		float 方向角度 = 
			Mathf.PerlinNoise (
				当前时刻_秒 * _随机变化速率, _YStart) * 3600.0f;
		Vector2 位移 = _速率 * Vector2.one;
		Quaternion 随机方向 = 
			Quaternion.AngleAxis(方向角度,new Vector3(0,0,1.0f));
		位移 = 随机方向 * 位移;

		transform.Translate (位移);
	}
}
