using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_SimpleKeyframe12 : MonoBehaviour {

	public int HP =1;

	public AnimationCurve _ScaleVSHP;

	public AnimationCurve _X,_Y;




	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.realtimeSinceStartup;

		float mx = (float)Input.mousePosition.x * 0.01f;

		float y = _Y.Evaluate (t);
		float x = _X.Evaluate (y);
		transform.localPosition = new Vector3 (x, y, 0);

		float scl = _ScaleVSHP.Evaluate ((float)HP);
		transform.localScale = new Vector3 (scl, scl, 1.0f);
		
	}
}
