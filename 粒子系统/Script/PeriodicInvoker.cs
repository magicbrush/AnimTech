using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PeriodicInvoker : MonoBehaviour {
	public float _Period = 1.0f;
	private float _LeftTime ;

	public UnityEvent _Happen;

	// Use this for initialization
	void Start () {
		_LeftTime = _Period;
	}
	
	// Update is called once per frame
	void Update () {
		if (_LeftTime <= 0) {
			// happen
			_Happen.Invoke();

			// set lefttime
			_LeftTime += _Period;
		}

		_LeftTime -= Time.deltaTime;
	}
}
