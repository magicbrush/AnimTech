using UnityEngine;
using System.Collections;

public class AT噪声色彩HSV : MonoBehaviour {

	public Vector3 _速率系数 = Vector3.one;
	public Vector3 _噪声变化速率 = new Vector3(1.0f,0,0);
	private Vector3 _噪声变化的斜率 = new Vector3(1.0f,1.111f,1.07321f);
	private Vector3 _噪声变化的Y起点 = Vector3.zero;

	public Bounds _HSV范围;
	public bool _在开始时吸取颜色 = true;


	// Use this for initialization
	void Start () {
		_噪声变化的Y起点 = new Vector3 (
			Random.value, Random.value, Random.value);
		if (_在开始时吸取颜色) {
			吸取当前色彩 ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		float 当前透明度 = sr.color.a;

		float 时刻 = Time.realtimeSinceStartup;
		Vector3 HSV = Vector3.zero;
		for (int i = 0; i < 3; i++) {
			float X = _噪声变化速率 [i] * 时刻;
			float Y = X * _噪声变化的斜率[i];
			float value = Mathf.PerlinNoise (X, Y + _噪声变化的Y起点 [i]);
			HSV [i] = AT_MathUtil.map (value, 0, 1.0f, _HSV范围.min [i], _HSV范围.max [i]);
		}
		HSV [0] = Mathf.Repeat (HSV [0], 1.0f);
		HSV [1] = Mathf.Clamp01 (HSV [1]);
		HSV [2] = Mathf.Clamp01(HSV[2]);
		Color 当前颜色 = 
			Color.HSVToRGB (HSV [0], HSV [1], HSV [2]);
		当前颜色.a = 当前透明度;

		sr.color = 当前颜色;
	}

	[ContextMenu("吸取当前色彩")]
	public void 吸取当前色彩()
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		Color 当前色彩 = sr.color;
		float H, S, V;
		Color.RGBToHSV (当前色彩, out H, out S, out V);
		_HSV范围.center = new Vector3 (H,S,V);
	}

	[ContextMenu("初始化噪声参数")]
	public void 初始化噪声参数()
	{
		_噪声变化速率 = new Vector3(
			Random.Range(0.5f,1.5f)*_速率系数.x,
			Random.Range(0.5f,1.5f)*_速率系数.y,
			Random.Range(0.5f,1.5f)*_速率系数.z);
		_噪声变化的斜率 = new Vector3(
			Random.Range(0.5f,1.5f),
			Random.Range(0.5f,1.5f),
			Random.Range(0.5f,1.5f));
		_噪声变化的Y起点 = new Vector3(
			Random.Range(0.5f,1.5f)*100.0f,
			Random.Range(0.5f,1.5f)*100.0f,
			Random.Range(0.5f,1.5f)*100.0f);
	}

}
