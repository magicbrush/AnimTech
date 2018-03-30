using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AT振子色彩 : MonoBehaviour {

	public FourierSynthesis _H, _S, _V,_A;

	public float _StartTime = 0.0f;
	// Use this for initialization
	void Start () {
		记录初始时刻 ();
	}
	
	// Update is called once per frame
	void Update () {
		float T = Time.realtimeSinceStartup - _StartTime;
		float H = _H.Evaluate (T);
		float S = _S.Evaluate (T);
		float V = _S.Evaluate (T);
		float A = _A.Evaluate (T);

		Color Cr = Color.HSVToRGB (H, S, V);
		Cr.a = A;

		SpriteRenderer SR = GetComponent<SpriteRenderer> ();
		SR.color = Cr;
	}

	public void 记录初始时刻()
	{
		_StartTime = Time.realtimeSinceStartup;
	}
}
