using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT振子尺寸 : MonoBehaviour {

	public FourierSynthesis _SX,_SY;

	public float _StartTime = 0.0f;

	// Use this for initialization
	void Start () {
		记录初始时刻 ();
	}
	
	// Update is called once per frame
	void Update () {
		float T = Time.realtimeSinceStartup - _StartTime;
		Vector3 Scl = new Vector3 (_SX.Evaluate (T), _SY.Evaluate (T), 1.0f);
		transform.localScale = Scl;
	}

	public void 记录初始时刻()
	{
		_StartTime = Time.realtimeSinceStartup;
	}
}
