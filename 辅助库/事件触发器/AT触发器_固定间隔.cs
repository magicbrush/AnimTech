using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AT触发器_固定间隔 : MonoBehaviour {

	public UnityEvent _触发;
	public float _时间间隔 = 1.0f;

	private float _剩余时间 = 1.0f;

	// Use this for initialization
	void Start () {
		_剩余时间 = _时间间隔;
	}
	
	// Update is called once per frame
	void Update () {
		_剩余时间 -= Time.deltaTime;

		if (_剩余时间 <= 0.0f) {
			_触发.Invoke ();
			_剩余时间 = _时间间隔;
		}

	}
}
