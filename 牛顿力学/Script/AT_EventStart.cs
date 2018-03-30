using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AT_EventStart : MonoBehaviour {

	public UnityEvent _Happen;

	// Use this for initialization
	void Start () {
		_Happen.Invoke ();
	}
	

}
