using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPTRun_SplahsDropNumFromHP : MonoBehaviour {

	public AT触发器_随机n次 _RandomInvoker;

	public float _Multiplier = 5.0f;
	public float _RandomBound = 5.0f;
	public float _Min = 10.0f;
	public ATTraceRunner _Runner;

	public bool _SetInUpdate = true;

	public void SetNum()
	{
		float hp = _Runner._Status.HP;

		float numMean = hp * _Multiplier + (float)_Min;

		float minNum = numMean - _RandomBound;
		float maxNum = numMean + _RandomBound;

		_RandomInvoker._Min = (int)minNum;
		_RandomInvoker._Max = (int)maxNum;
	}

	public void Update()
	{
		if (_SetInUpdate) {
			SetNum ();
		}
	}
}
