using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_Attraction1 : MonoBehaviour {
	public float _G = 1.0f;
	public float _DistMin = 0.5f,_DistMax = 5.0f;
	public float _DistanceMulitiplier = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// 吸引同组的所有其他球
		int siblingCount = transform.parent.childCount;

		for (int i = 0; i < siblingCount; i++) {
			Transform tfSibling = transform.parent.GetChild (i);

			// 如果是自己，就跳过本次循环
			if (tfSibling == transform) {
				continue;
			}

			// 算出力的方向
			Vector2 posThis = (Vector2)transform.position;
			Vector2 posOther = (Vector2)tfSibling.position;
			Vector2 thisToOther = posOther - posThis;
			Vector2 forceDir = thisToOther.normalized;

			// 算出力的大小
			Rigidbody2D rbThis = 
				GetComponent<Rigidbody2D>();
			Rigidbody2D rbOther = 
				tfSibling.GetComponent<Rigidbody2D> ();
			float massThis = rbThis.mass;
			float massOther = rbOther.mass;
			float distance = 
				_DistanceMulitiplier * thisToOther.magnitude;
			distance = 
				Mathf.Clamp (distance, _DistMin, _DistMax);

			float forceMag =
				_G * massThis * massOther / 
				(distance * distance);

			// 受力的作用
			Vector2 force = forceMag * forceDir;
			rbThis.AddForce (force);
		}


	}
}
