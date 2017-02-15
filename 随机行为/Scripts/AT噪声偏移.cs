using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AT噪声偏移 : MonoBehaviour {

	public Vector3 _速率系数 = Vector3.one;
	public bool _全局位置 = true;
	private Vector3 _基准位置 = new Vector3(float.NegativeInfinity,0,0);
	public  Vector2 [] _噪声速率 = new Vector2[]{
		Random.insideUnitCircle,
		Random.insideUnitCircle,
		Random.insideUnitCircle};
	public float _偏移最大距离 = 1.0f;

	public Vector2 _噪声起始点 = 
		100.0f*Random.insideUnitCircle;

	// Use this for initialization
	void Start () {
		if (_基准位置.x == float.NegativeInfinity) {
			记录当前位置为基准位置 ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		float 时刻 = Time.realtimeSinceStartup;
		Vector3 偏移量 = Vector3.zero;
		for (int i = 0; i < 3; i++) {
			float 甲 = _噪声起始点.x + 时刻 * _噪声速率 [i].x;
			float 乙 = _噪声起始点.y + 时刻 * _噪声速率 [i].y;
			偏移量 [i] = _偏移最大距离 * (Mathf.PerlinNoise(甲,乙)*2.0f-1.0f);
		}
		Vector3 位置 = _基准位置 + 偏移量;

		if (_全局位置) {
			transform.position = 位置;
		} else {
			transform.localPosition = 位置;
		}
	}

	[ContextMenu("记录当前位置为基准位置")]
	public void 记录当前位置为基准位置()
	{
		if (_全局位置) {
			_基准位置 = 
				transform.position;
		} else {
			_基准位置 = 
				transform.localPosition;
		}
	}

	[ContextMenu("初始化噪声参数")]
	public void 初始化噪声参数()
	{
		for (int i = 0; i < 3; i++) {
			_噪声速率 [i] = Random.insideUnitCircle * _速率系数[i];
		}
		_噪声起始点 = 100.0f * Random.insideUnitCircle;
	}
}
