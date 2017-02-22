using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 随机旋转0 : MonoBehaviour {

	public float _旋转速率 = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float 旋转角度 = Random.Range (
			-15.0f*_旋转速率, 15.0f*_旋转速率);
		transform.Rotate (Vector3.forward, 旋转角度);
		
	}
}
