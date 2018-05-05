using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class RandomFloat : MonoBehaviour {

	[System.Serializable]
	public class EventFloat: UnityEvent<float>{};
	public EventFloat _RandFloat;

	public float _Min = 1.0f,_Max = 10.0f;

	// Use this for initialization
	void Start () {
		float rvalue = Random.Range (_Min, _Max);
		_RandFloat.Invoke (rvalue);
		//_RandFloat.AddListener
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
