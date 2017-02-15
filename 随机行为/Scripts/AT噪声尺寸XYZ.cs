using UnityEngine;
using System.Collections;

public class AT噪声尺寸XYZ : MonoBehaviour {
	public Vector3 _速率系数 = Vector3.one;
	public Vector3 [] _噪声速率 = new Vector3[]{
		Random.insideUnitSphere,
		Random.insideUnitSphere,
		Random.insideUnitSphere};
	public Vector3 [] _噪声起点 = new Vector3[]{
		Random.insideUnitSphere * 100.0f,
		Random.insideUnitSphere * 100.0f,
		Random.insideUnitSphere * 100.0f};
	public Vector3 
		_最小尺度 = 0.8f* Vector3.one,
		_最大尺度 = 1.2f* Vector3.one;

	private Vector3 _基准尺度 = new Vector3(float.NegativeInfinity,0,0);

	// Use this for initialization
	void Start () {
		if (_基准尺度.x == float.NegativeInfinity) {
			以当前尺度为基准尺度 ();
		}
	}

	// Update is called once per frame
	void Update () {
		float 当前时刻_秒 = Time.realtimeSinceStartup;

		Vector3 随机化尺度 = _基准尺度;
		for (int i = 0; i < 3; i++) {
			Vector2 噪声位置 = _噪声起点[i] + 当前时刻_秒 * _噪声速率 [i];
			float 尺度改变 = Mathf.PerlinNoise(噪声位置.x, 噪声位置.y);
			float 尺度改变系数 = AT_MathUtil.map (
				尺度改变, 0, 1.0f, _最小尺度 [i], _最大尺度 [i]);
			随机化尺度 [i] *= 尺度改变系数;
		}

		transform.localScale = 随机化尺度;
	}

	[ContextMenu("以当前尺度为基准尺度")]
	public void 以当前尺度为基准尺度()
	{
		_基准尺度 = transform.localScale;
	}

	[ContextMenu("初始化噪声参数")]
	public void 初始化噪声参数()
	{
		for (int i = 0; i < 3; i++) {
			_噪声速率 [i] = Random.insideUnitSphere* _速率系数[i];
			_噪声起点 [i] = Random.insideUnitSphere * 100.0f;
		}
	}
}
