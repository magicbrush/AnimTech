using UnityEngine;
using System.Collections;

public class AT简单随机旋转 : MonoBehaviour {
	public float _最大旋转角度 = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float 随机旋转角度 = Random.Range (-_最大旋转角度, _最大旋转角度);
		transform.Rotate (0, 0, 随机旋转角度);
	}
}
