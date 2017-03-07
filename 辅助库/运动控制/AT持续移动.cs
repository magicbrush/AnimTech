using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT持续移动 : MonoBehaviour {
	public bool _在局部空间移动 = true;
	public Vector3 _速度 = new Vector3 (1.0f, 0, 0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		Vector3 位移 = dt * _速度;
		if (_在局部空间移动) {
			transform.localPosition += 位移;
		} else {
			transform.position += 位移;
		}

	}
}
