using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATRandomScaleAtStart : MonoBehaviour {

	public float _ScaleMin = 0.5f,_ScaleMax= 1.5f;
	// Use this for initialization
	void Start () {
		float scl = Random.Range (_ScaleMin, _ScaleMax);
		transform.localScale = scl * Vector3.one;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
