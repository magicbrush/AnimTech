using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT振子运动 : MonoBehaviour {

	public FourierSynthesis _X, _Y,_Z;

	private float _起始时刻 = 0.0f;
	private Vector3 _起始位置 = Vector3.zero;

	// Use this for initialization
	void Start () {
		重置起始时刻 ();
		重置起始位置 ();
	}
	
	// Update is called once per frame
	void Update () {
		float 流逝时间 = Time.realtimeSinceStartup - _起始时刻;

		float x = _X.Evaluate (流逝时间);
		float y = _Y.Evaluate (流逝时间);
		float z = _Z.Evaluate (流逝时间);

		transform.localPosition =  _起始位置 + new Vector3 (x, y, z);
		
	}

	public void 重置起始时刻和位置()
	{
		重置起始时刻 ();
		重置起始位置 ();

	}
	public void 重置起始时刻()
	{
		_起始时刻 = Time.realtimeSinceStartup;
	}

	public void 重置起始位置()
	{
		_起始位置 = Vector3.zero;
	}
}
