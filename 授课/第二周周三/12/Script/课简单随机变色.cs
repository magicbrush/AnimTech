using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 课简单随机变色 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SpriteRenderer sr;
		sr = GetComponent<SpriteRenderer> ();
		Color cr = Random.ColorHSV ();
		cr.a = Random.Range (0.0f, 1.0f);
		sr.color = cr;
	}
}
