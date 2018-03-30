using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AT周期位移 : AT周期行为基类 {

	[System.Serializable]
	public struct 偏移量
	{
		public FourierSynthesis _DX,_DY,_DZ;
	}
	public 偏移量 _偏移量;

	public bool _全局位置 = true;
	private Vector3 _基准位置 = new Vector3(float.NegativeInfinity,0,0);

	// Use this for initialization
	void Start () {
		初始化基准时刻();
		if (_基准位置.x == float.NegativeInfinity) {
			以当前位置为基准位置 ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		float 时刻 = Time.realtimeSinceStartup - _基准时刻;
		Vector3 偏移 = new Vector3(
			_偏移量._DX.Evaluate(时刻),
			_偏移量._DY.Evaluate(时刻),
			_偏移量._DZ.Evaluate(时刻));

		Vector3 位置 = _基准位置 + 偏移;

		if (_全局位置) {
			transform.position = 位置;
		} else {
			transform.localPosition = 位置;
		}
	}

	[ContextMenu("以当前位置为基准位置")]
	public void 以当前位置为基准位置()
	{
		if (_全局位置) {
			_基准位置 = transform.position;
		} else {
			_基准位置 = transform.localPosition;
		}
	}

}
