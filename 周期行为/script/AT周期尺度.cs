using UnityEngine;
using System.Collections;

public class AT周期尺度 : AT周期行为基类 {

	[System.Serializable]
	public struct 尺度变化比例
	{
		public FourierSynthesis _SX,_SY,_SZ;
	}
	public 尺度变化比例 _变化比例;
	private Vector3 _基准尺度 = new Vector3(float.NegativeInfinity,0,0);

	// Use this for initialization
	void Start () {
		初始化基准时刻();
		if (_基准尺度.x == float.NegativeInfinity) {
			以当前尺度为基准尺度 ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		float 时刻 = Time.realtimeSinceStartup - _基准时刻;
		Vector3 尺度变化量 = new Vector3(
			_变化比例._SX.Evaluate(时刻),
			_变化比例._SY.Evaluate(时刻),
			_变化比例._SZ.Evaluate(时刻));

		Vector3 尺度 = _基准尺度 + 尺度变化量 ;
		transform.localScale = 尺度;
	}

	[ContextMenu("以当前尺度为基准尺度")]
	public void 以当前尺度为基准尺度()
	{
		_基准尺度 = transform.localScale;
	}
}
