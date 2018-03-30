using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_Attraction : MonoBehaviour {

	public float _G = 1.0f;
	public float _DistanceMultiplier = 0.2f;
	public float _MinDistance = 0.5f;
	public float _MaxDistance = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		int SiblingCount = transform.parent.childCount;
		for (int i = 0; i < SiblingCount; i++) {
			Transform siblingTF = 
				transform.parent.GetChild (i);

			// 如果是自己，就跳过这一次循环
			if (siblingTF == transform) {
				continue;
			}
		
			// 算力的方向
			Vector2 PosMe = (Vector2)transform.position;
			Vector2 PosSib = (Vector2)siblingTF.position;
			Vector2 MeToSib = PosSib - PosMe;
			Vector2 ForceDir = MeToSib.normalized;

			// 算力的大小
			Rigidbody2D rbMe = 
				GetComponent<Rigidbody2D>();
			Rigidbody2D rbSib = 
				siblingTF.GetComponent<Rigidbody2D>();
			float MassMe = rbMe.mass;
			float MassSib = rbSib.mass;
			float Distance = 
				_DistanceMultiplier * 
					Mathf.Clamp(MeToSib.magnitude, _MinDistance,_MaxDistance);
			float ForceMag =
				_G * MassMe * MassSib / (Distance * Distance);

			// 施加力的作用
			Vector2 Force = ForceMag * ForceDir;
			rbMe.AddForce (Force);
		}


		
	}
}
