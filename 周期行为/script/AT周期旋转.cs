using UnityEngine;
using System.Collections;

public class AT周期旋转 : AT周期行为基类 {

	public FourierSynthesis _旋转角度;

	public bool _增量式旋转 = false;

	// Use this for initialization
	void Start () {
		初始化基准时刻();
	}
	
	// Update is called once per frame
	void Update () {
		float 角度 =
			_旋转角度.Evaluate (Time.realtimeSinceStartup - _基准时刻);
		Quaternion 旋转 = 
			Quaternion.AngleAxis (角度, Vector3.forward);
		if (!_增量式旋转) {
				transform.localRotation = 旋转;
		} else {
				transform.localRotation *= 旋转;
		}
	}
}
