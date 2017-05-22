using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyframe : MonoBehaviour {


	public AnimationCurve _X,_Y;
	public AnimationCurve _transparency;
	public AnimationCurve _Scale;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		float t = Time.realtimeSinceStartup;

		float mx = (float)Input.mousePosition.x * 0.01f;

		float y = _Y.Evaluate (t);
		float x = _X.Evaluate (t);
		transform.localPosition = new Vector3 (x, y, 0);

		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		Color now_clolr = sr.color;
		float colora = _transparency.Evaluate (t);
		now_clolr.a = colora;
		sr.color = now_clolr ;

		float scl = _Scale.Evaluate (t);
		transform.localScale = new Vector3 (scl, scl, 1.0f);
	}
}
