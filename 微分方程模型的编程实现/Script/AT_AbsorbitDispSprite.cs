using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AT_AbsorbitDispSprite : MonoBehaviour {
	public AT_Absorbit _absorbit;
	//public SpriteRenderer _spr;
	public Color _BaseColor;
	public float _Power = 1.0f;
	
	// Update is called once per frame
	void Update () {
		//float c = absorbit.GetC ();
		float rho = _absorbit.GetRho ();

		Color cr = _BaseColor;
		cr.a = Mathf.Pow( rho, _Power);
		SpriteRenderer spr = GetComponent<SpriteRenderer> ();
		spr.color = cr;
	}
}
