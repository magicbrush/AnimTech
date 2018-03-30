using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT随机化_尺寸 : MonoBehaviour {

	public float _Min, _Max;

	[ContextMenu("Randomize")]
	public void 随机化()
	{
		Vector3 scl = Random.Range (_Min, _Max) * Vector3.one;
		transform.localScale = scl;
	}
}
