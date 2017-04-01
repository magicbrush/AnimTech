using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT定时死亡 : MonoBehaviour {

	public float _LiftSpan = 1.0f;
	
	// Update is called once per frame
	void Update () {
		
		if (_LiftSpan <= 0.0f) {
			Destroy (gameObject);
		}
		_LiftSpan -= Time.deltaTime;
		
	}

	public void SetLifeSpan(float lifeSpan = 1.0f)
	{
		_LiftSpan = lifeSpan;
	}
}
