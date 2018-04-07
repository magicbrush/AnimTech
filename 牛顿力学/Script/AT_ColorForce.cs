using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AT_ColorForce : MonoBehaviour {
	public Color _Color;
	public AT_ColorForce _Other;
	public float _ForceFactor = 1.0f;
	public float _DistFactor = 0.2f;
	
	// Update is called once per frame
	void Update () {

		// 获取自己和对方颜色
		Color colorMe = _Color;
		Color colorHe = _Other._Color;

		// 计算力的方向
		Vector3 MeToOther =
			_Other.transform.position - transform.position;
		Vector3 forceDir = MeToOther.normalized;

		// 计算力的大小
		float colorDiff = 
			Mathf.Abs(colorMe.r - colorHe.r) + 
			Mathf.Abs(colorMe.g - colorHe.g) + 
			Mathf.Abs(colorMe.b - colorHe.b);
		float forceMag = _ForceFactor * colorDiff/
			(_DistFactor*MeToOther.magnitude);

		// 施加力的作用（只作用在自己）
		Vector2 force = (Vector2)forceDir * forceMag;
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (force);

	}
}
