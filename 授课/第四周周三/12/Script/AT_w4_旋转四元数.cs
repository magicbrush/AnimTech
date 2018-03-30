using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_w4_旋转四元数 : MonoBehaviour {
	public Vector3 _目标方向= Vector3.right;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Quaternion Rot = 
			Quaternion.FromToRotation (Vector3.right, _目标方向);

		Quaternion DeltaRot = 
			Quaternion.Lerp (transform.localRotation, Rot,0.03f);

		transform.localRotation = DeltaRot;
	}

	public void 随机化目标方向()
	{
		_目标方向 = Random.insideUnitSphere;
	}
}
