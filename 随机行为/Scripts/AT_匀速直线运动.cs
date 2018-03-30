using UnityEngine;
using System.Collections;

public class AT_匀速直线运动 : MonoBehaviour {

	public Vector3  _速度 = Vector3.zero;
	public float _最大速率 = 1.0f;

	// Use this for initialization
	void Start () {
		随机化速度 ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 移动量 = Time.deltaTime * _速度;
		transform.Translate (移动量);
	}

	public void 随机化速度()
	{
		_速度 = _最大速率 * Random.insideUnitCircle;
	}
}
