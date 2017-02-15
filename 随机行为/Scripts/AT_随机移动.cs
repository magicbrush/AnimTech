using UnityEngine;
using System.Collections;

public class AT_随机移动 : MonoBehaviour {

	public AnimationCurve _移动方向概率分布;
	public float _步长 = 0.01f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float 随机角度 =
			AT自定概率分布随机值生成器.根据分布生成随机数 (
			_移动方向概率分布, 0.0f, 1.0f) * 360.0f;

		Vector3 移动量 = _步长 * Vector3.right;
		Quaternion 随机旋转量 = Quaternion.AngleAxis (随机角度, Vector3.forward);
		移动量 = 随机旋转量 * 移动量;

		transform.Translate (移动量);
	}
}
