using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT滤波器 : MonoBehaviour {

	public AnimationCurve _FreqResponse;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		AT振子运动 振动 = other.GetComponent<AT振子运动> ();
		for(int i=0;i<3;i++)
		{

		}
	}
}
