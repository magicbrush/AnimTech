using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 随机缩放0 : MonoBehaviour {

	public float _缩放强度 = 1.0f;
	
	// Update is called once per frame
	void Update () {
		Vector3 尺度变化量 = new Vector3 (
			Random.Range(-0.01f*_缩放强度,0.01f*_缩放强度),
			Random.Range(-0.01f*_缩放强度,0.01f*_缩放强度),0);
		transform.localScale += 尺度变化量;
		
	}
}
