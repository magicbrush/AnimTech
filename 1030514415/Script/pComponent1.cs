using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pComponent1 : MonoBehaviour {
	public float _ForceMultiplier = 1.0f;
	public float time = 0.0f;

	void Start () {
	}

	void Update () {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
	    time = Time.realtimeSinceStartup;
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		RandomAction (rb);
		ChangeColor (sr);
	}

	public void RandomAction( Rigidbody2D Rb ) {
		Rb.AddForce ( Random.insideUnitCircle * _ForceMultiplier);
	}
		
	public void ChangeColor(SpriteRenderer SR) {
		
		float NewColor_H, NewColor_S, NewColor_V;
		float Change_S, Change_V;
		float  ChangeColor_S, ChangeColor_V;
		Color.RGBToHSV (SR.color, out NewColor_H, out NewColor_S, out NewColor_V);

		Change_S = Random.Range (-0.03f * Random.value, 0.03f * Random.value);
		Change_V = Random.Range (-0.03f * Random.value, 0.03f * Random.value);

		ChangeColor_S = Mathf.Clamp01 (NewColor_S + Change_S );
		ChangeColor_V = Mathf.Clamp01 (NewColor_V + Change_V);

		SR.color = Color.HSVToRGB (NewColor_H,ChangeColor_S,ChangeColor_V);
	}
}

