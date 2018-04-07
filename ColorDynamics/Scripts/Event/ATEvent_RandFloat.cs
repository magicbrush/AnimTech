using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ATEvent_RandFloat : MonoBehaviour {
	public float _Min = 0.0f, _Max = 1.0f;
	[System.Serializable]
	public class EventWithFloat: UnityEvent<float>{};
	public EventWithFloat _RandFloat;

	public void InvokeEvent()
	{
		_RandFloat.Invoke (Random.Range (_Min, _Max));	
	}



}
