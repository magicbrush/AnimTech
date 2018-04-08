using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_1stODE1 : MonoBehaviour {

	public float _kx=1.0f,_ky =1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 localPos = (Vector2)transform.localPosition;
		float dx = _kx * localPos.y * Time.deltaTime;
		float dy = _ky * localPos.x * Time.deltaTime;

		localPos += new Vector2 (dx, dy);
		transform.localPosition = localPos;
	}
}
