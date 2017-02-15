using UnityEngine;
using System.Collections;

public class AT_随机方向 : MonoBehaviour {

	public AnimationCurve _方向概率分布;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float 随机角度 =
			AT自定概率分布随机值生成器.根据分布生成随机数 (
				_方向概率分布, 0.0f, 1.0f) * 360.0f;

		Quaternion 方向 = Quaternion.AngleAxis (随机角度, Vector3.forward);
		transform.localRotation = 方向;
	}
}
