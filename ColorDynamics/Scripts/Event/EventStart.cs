using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventStart : MonoBehaviour {

	public UnityEvent _Start;
	public void Start()
	{
		_Start.Invoke ();
	}

}
