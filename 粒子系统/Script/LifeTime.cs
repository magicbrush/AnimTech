using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour {

	public float _LeftTime = 5.0f;

	// Use this for initialization
	void Start () {
		
	}

	public void SetLeftTime(float leftT)
	{
		_LeftTime = leftT;
	}
	
	// Update is called once per frame
	void Update () {

		if (_LeftTime <= 0.0f) {
			Destroy (gameObject);
		}

		_LeftTime -= Time.deltaTime;
		
	}
}
