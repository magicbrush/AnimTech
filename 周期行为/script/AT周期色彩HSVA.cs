using UnityEngine;
using System.Collections;

public class AT周期色彩HSVA : AT周期行为基类 {

	[System.Serializable]
	public struct 色彩变化
	{
		public FourierSynthesis _DH,_DS,_DV,_DA;
	}
	public 色彩变化 _色变;

	[System.Serializable]
	public class 基准色
	{
		public float 
			H=float.NegativeInfinity,
			S=float.NegativeInfinity,
			V=float.NegativeInfinity,
			A=float.NegativeInfinity;
	}
	public 基准色 _基准色;

	// Use this for initialization
	void Start () {
		初始化基准时刻();
		if (_基准色.H == float.NegativeInfinity) {
			以当前颜色作为基准色 ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		float 时刻 = Time.realtimeSinceStartup - _基准时刻;

		var 色彩变化HSVA = 计算当前时刻的色彩变化量 (时刻);
		Vector4 基准色彩HSVA = new Vector4 (
			_基准色.H,_基准色.S,_基准色.V,_基准色.A);
		Vector4 变化后的色彩HSVA = 基准色彩HSVA + 色彩变化HSVA;
		让色彩值不超出取值范围 (变化后的色彩HSVA);
		Color 变化后的色彩RGB = Color.HSVToRGB (
			变化后的色彩HSVA [0], 变化后的色彩HSVA [1], 变化后的色彩HSVA [2]);
		变化后的色彩RGB.a = 变化后的色彩HSVA [3];

		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.color = 变化后的色彩RGB;
	}

	Vector4 计算当前时刻的色彩变化量 (float 时刻)
	{
		Vector4 色彩变化HSVA = new Vector4 (
			_色变._DH.Evaluate (时刻), 
			_色变._DS.Evaluate (时刻), 
			_色变._DV.Evaluate (时刻), 
			_色变._DA.Evaluate (时刻));
		return 色彩变化HSVA;
	}

	static void 让色彩值不超出取值范围 (Vector4 色彩HSVA)
	{
		色彩HSVA [0] = Mathf.Repeat (色彩HSVA [0], 1.0f);
		for (int i = 1; i < 4; i++) {
			色彩HSVA [i] = Mathf.Clamp01 (色彩HSVA [i]);
		}
	}

	[ContextMenu("以当前颜色作为基准色")]
	public void 以当前颜色作为基准色()
	{
		Color 当前rgb色彩 = GetComponent<SpriteRenderer> ().color;
		Color.RGBToHSV (
			当前rgb色彩, 
			out _基准色.H, 
			out _基准色.S, 
			out _基准色.V);
		_基准色.A = 当前rgb色彩.a;
	}
}
