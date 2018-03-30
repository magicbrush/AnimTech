using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AT触发器_随机n次 : MonoBehaviour {

	public UnityEvent _触发;

	public int _Min=0, _Max=10;

	public void 触发()
	{
		int num = Random.Range (_Min, _Max);

		for (int i = 0; i < num; i++) {
			_触发.Invoke ();
		}

	}
}
