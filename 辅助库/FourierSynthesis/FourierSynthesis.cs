using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class FourierSynthesis {
	public List<Vector3> _正弦参数组;

	public float Evaluate(float t)
	{
		float 和 = 0.0f;
		foreach (Vector3 参数 in _正弦参数组) {
			float 振幅 = 参数.x;
			float 频率 = 参数.y;
			float 相位 = 参数.z;
			float 正弦分量 = 振幅 * Mathf.Sin (频率 * t + 相位);
			和 += 正弦分量;
		}
		return 和;
	}
}
