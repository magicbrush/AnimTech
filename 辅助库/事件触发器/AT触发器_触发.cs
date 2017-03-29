using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AT触发器_触发 : MonoBehaviour {

	public UnityEvent _触发;

	public void 触发()
	{
		_触发.Invoke ();
	}
}
