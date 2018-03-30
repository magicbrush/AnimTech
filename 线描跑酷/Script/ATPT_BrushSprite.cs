using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPT_BrushSprite : MonoBehaviour {
	public ATTraceRunner _Runner;
	// Use this for initialization
	void Start () {
		if (_Runner == null) {
			_Runner = GetComponentInParent<ATTraceRunner> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Die()
	{
		_Runner._Status.SetHP(0);
	}
}
