using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pInherited1 : pBase  {
	//加了透明度啊喂
	public float change = 10f; 
	private float o_transparency;
	public float  n_transparency= 0.3f;

	// Use this for initialization
	void Start () {
		o_transparency = GetComponent<SpriteRenderer> ().color.a;  //原始透明度
	}

	// Update is called once per frame
	public override void Update () {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		base.Update ();
		float time = Time.realtimeSinceStartup;
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		Color now_clolr = sr.color;

		float transparency = now_clolr.a;
		transparency = Random.Range(0.0f,1.0f);
		transparency = AT_MathUtil.map (transparency, 0.0f,1.0f,
			n_transparency - change, 
			n_transparency + change);
		
		now_clolr.a = transparency;

		sr.color = now_clolr;
	}

	public void now_transparency() {
		n_transparency = GetComponent<SpriteRenderer> ().color.a;
	}
}
	
