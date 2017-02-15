using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AT触发器_定时 : MonoBehaviour {

	public UnityEvent _触发;

	public float _剩余时间= 1.0f;

	
	// Update is called once per frame
	void Update () {
		if (_剩余时间 > 0.0f) {
			_剩余时间 -= Time.deltaTime;
			return;
		}
		_触发.Invoke ();
	}
}
