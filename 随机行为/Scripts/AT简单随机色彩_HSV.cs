using UnityEngine;
using System.Collections;

public class AT简单随机色彩_HSV : MonoBehaviour {
	public float _最大变化量H = 0.01f;
	public float _最大变化量S = 0.01f;
	public float _最大变化量V = 0.01f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();

		float 当前颜色H, 当前颜色S, 当前颜色V;
		Color.RGBToHSV (sr.color, out 当前颜色H, out 当前颜色S, out 当前颜色V);

		float 色相改变量 = Random.Range (-_最大变化量H, _最大变化量H);
		float 饱和度改变量 = Random.Range (-_最大变化量S, _最大变化量S);
		float 明度改变量 = Random.Range (-_最大变化量V, _最大变化量V);

		float 改变后颜色H, 改变后颜色S, 改变后颜色V;
		改变后颜色H = Mathf.Repeat (当前颜色H + 色相改变量,1.0f);
		改变后颜色S = Mathf.Clamp01 (当前颜色S + 饱和度改变量);
		改变后颜色V = Mathf.Clamp01 (当前颜色V + 明度改变量);

		Color 随机变化后的颜色_rgb模式 = 
			Color.HSVToRGB (改变后颜色H,改变后颜色S,改变后颜色V);
		sr.color = 随机变化后的颜色_rgb模式;
	}
}
